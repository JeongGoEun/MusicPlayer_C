using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Shell32;
using WMPLib;
using socketProtocol_Library;  //mp3통신을 위한 패킷

namespace mp3_client
{
    public partial class Client : Form
    {
        /*통신을 위한 변수*/
        private NetworkStream m_NetStream;
        private TcpClient m_Client;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        private bool m_blsCientOn = false;

        /*클라이언트 파일을 위한 변수*/
        private string downPath;
        private string FileDownPath;
        FileStream filestream;
        public MusicName MusicNameClass;
        private Thread m_Thread;

        Folder folder;
        ListViewItem item;
        private string FileName;
        ShellClass shell = new ShellClass();

        /*음악 재생을 위한 변수*/
        private WindowsMediaPlayer WMP;
        //WMPMedia Media=new IWMPMedia();  //음악 파일 저장 배열
        IWMPPlaylist MusicPlayList;    //저장할 플레이리스트
        IWMPPlaylist newPlayList;   //한 곡 저장 리스트
        bool checkState = true;
        int playIndex = 0;  //현재 재생중인 인덱스 저장
        int oneSongIndex = 0;
        int randomCheck = 0;

        public Client()
        {
            InitializeComponent();
        }

        private void connectBtn_Click(object sender, EventArgs e)   //서버와 연결
        {
            //Txt.Text = "192.168.230.1"; portTxt.Text = "7000";
            if (ipTxt.Text.CompareTo("") == 0 || portTxt.Text.CompareTo("") == 0)   //IP와 port번호 입력하지 않았을 때
            {
                MessageBox.Show("ip 혹은 Port Numer가 설정되지 않았습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ipTxt.Text = ""; portTxt.Text = "";
            }
            else
            {
                this.m_Client = new TcpClient();
                try
                {
                    this.m_Client.Connect(this.ipTxt.Text,Convert.ToInt32(portTxt.Text));
                    this.connectBtn.ForeColor = Color.Red;
                    this.connectBtn.Text = "DisConnect";
                }
                catch
                {
                    MessageBox.Show("Can Not Connection", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.m_blsCientOn = true;
                this.m_NetStream = this.m_Client.GetStream();   //서버의 스트림을 얻음
                this.m_Thread = new Thread(new ThreadStart(RECEIVE));   //받는 thread 실행
                m_Thread.Start();
            }
        }
        public void Send()  //원하는 데이터 요청
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();
            for(int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }
        public void RECEIVE()   //서버로 부터 받기
        {
            int check = 0;
            while (this.m_blsCientOn)
            {
                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_NetStream.Read(readBuffer, 0, readBuffer.Length);    //데이터 읽기
                    
                }
                catch
                {
                    this.m_blsCientOn = false;
                    this.m_NetStream = null;
                    return;
                    
                }

                Packet packet = (Packet)Packet.Deserialize(readBuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.SendToClient:  //처음 연결하고 리스트목록 받을 때
                        {
                            MusicName music = (MusicName)Packet.Deserialize(readBuffer);
                            this.Invoke(new MethodInvoker(delegate () { item = musicList.Items.Add(music.musicName); }));
                            this.Invoke(new MethodInvoker(delegate () { item.SubItems.Add(music.artistName); }));
                            this.Invoke(new MethodInvoker(delegate () { item.SubItems.Add(music.musicTime); }));
                            this.Invoke(new MethodInvoker(delegate () { item.SubItems.Add(music.bitRate); }));                                                 
                        }
                        break;

                    case (int)PacketType.ReceiveToServer:   //파일 받을 때
                        {
                            ClientFile cFile = (ClientFile)Packet.Deserialize(readBuffer);  //데이터 객체화
                            check++;    //파일 처음 확인

                            FileDownPath = downPath + "\\" + cFile.FileName;    //클라이언트 선택 경로+파일 이름
                            FileName = cFile.FileName;
                            if (check == 1) {   //파일 전송이 처음이면

                                this.Invoke(new MethodInvoker(delegate () { progressBar.Maximum = cFile.FileCount; }));
                                //프로그래스바 초기화
                                filestream = new FileStream(FileDownPath, FileMode.Append, FileAccess.Write);
                                //서버의 이름과 같은 파일 Create,Append
                            }

                            this.Invoke(new MethodInvoker(delegate () { progressBar.PerformStep(); }));//프로그래스바 확장
                            filestream.Write(cFile.FileData, 0, cFile.FileData.Length);

                            if (check == cFile.FileCount)   //파일 전체 전송 완료
                            {
                                this.Invoke(new MethodInvoker(delegate () { progressBar.PerformStep(); }));
                                filestream.Close();//파일 닫기
                                check = 0;  //check 초기화
                                this.Invoke(new MethodInvoker(delegate () { progressBar.Value = 0; })); //프로그래스바 초기화

                                /*플레이 리스트에 추가*/
                                IWMPMedia Media;
                                Media = WMP.newMedia(@FileDownPath);    //새로운 음악파일 객체 생성    
                                MusicPlayList.appendItem(Media);        //플레이리스트에 추가
                                
                            }
                        }
                        break;
                    case (int)PacketType.서버음악정보:  //처음 연결하고 리스트목록 받을 때
                        {
                            MusicName music = (MusicName)Packet.Deserialize(readBuffer);
                            this.Invoke(new MethodInvoker(delegate () { item = playList.Items.Add(music.musicName); }));
                            this.Invoke(new MethodInvoker(delegate () { item.SubItems.Add(music.artistName); }));
                            this.Invoke(new MethodInvoker(delegate () { item.SubItems.Add(music.musicTime); }));
                            this.Invoke(new MethodInvoker(delegate () { item.SubItems.Add(music.bitRate); }));
                        }
                        break;
                }
            }

        }
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_Client.Close();
            this.filestream.Close();
            this.m_NetStream.Close();
            this.m_blsCientOn = false;
            this.m_Thread.Abort();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Step = 1;
            WMP = new WindowsMediaPlayer();
            MusicPlayList = WMP.newPlaylist("MusicPlayer", "");
            WMP.currentPlaylist = MusicPlayList;
            comboBox1.SelectedIndex = 0;
        }

        private void findBtn_Click(object sender, EventArgs e)  //다운받을 경로 지정 버튼
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                  try
                    {
                        downPath = folderBrowserDialog1.SelectedPath;
                        this.downTxt.Text = downPath;
                    }
                    catch
                    {
                        MessageBox.Show("폴더 불러오기 에러");
                         return;
                    }
             }
         }

        private void add_list_Click(object sender, EventArgs e) //Music List - 재생목록의 추가 버튼
        {
            if (!this.m_blsCientOn) //client연결 되어 있지 않다면
                return;

            if (downTxt.Text.CompareTo("") == 0)    //다운 경로 지정하지 않았다면
            {
                DialogResult dr = MessageBox.Show("파일을 다운받을 경로를 지정하지 않았습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int index;
                index = musicList.FocusedItem.Index;    //선택 된 아이템 인덱스
                string musicName = musicList.Items[index].Text;

                ClientRequest request = new ClientRequest();    //ClientRequest로 요청하는 음악 제목 서버로 보냄
                request.Type = (int)PacketType.SendToServer;
                request.musicName = musicName;

                Packet.Serialize(request).CopyTo(sendBuffer, 0);
                this.Send();
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            //MusicPlayListAdd();
            int index=0;    
            int count=0;    //플레이리스트를 위한 인덱스
            index = playList.FocusedItem.Index; //리스트 뷰 선택 된 리스트
            playIndex = index;  //재생 중 파일 인덱스 저장
            string selectedMusic = playList.Items[index].SubItems[0].Text;
            
            if (playBtn.ImageIndex == 0)  //재생 중 이라면
            {
                playBtn.ImageIndex = 1;   //일시정지 버튼으로 바꿈
                if (randomCheck == 1)   //한곡 재생일 때
                {
                    choiceLabel.Text = "♬ " + playList.Items[oneSongIndex].SubItems[0].Text + "-" + playList.Items[oneSongIndex].SubItems[1].Text;
                    WMP.currentPlaylist = newPlayList;    //플레이리스트 새로 설정
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        WMP.controls.next();
                    }
                    choiceLabel.Text = "♬ " + playList.Items[index].SubItems[0].Text + "-" + playList.Items[index].SubItems[1].Text;
                }
                WMP.controls.play();
            }
            else
            {   //정지 버튼일 때
                if (checkState == true) //정지 상태
                {
                    WMP.controls.pause();   //다시 시작
                    checkState = false;
                }
                else
                {//플레이 상태
                    WMP.controls.play();   //중지
                    checkState = true;
                }
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (playIndex == 0) //리스트 예외 처리
            {
                MessageBox.Show("리스트의 처음 곡 입니다.");
            }
            else if (randomCheck == 1)
            {
                MessageBox.Show("한 곡 재생 입니다.");
            }
            else
            {
                WMP.controls.previous();    //이전 곡 이동
                playIndex--;    //현재 재생중인 인덱스 감소
                choiceLabel.Text = "♬ " + playList.Items[playIndex].SubItems[0].Text + "-" + playList.Items[playIndex].SubItems[1].Text; 
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (playIndex == (playList.Items.Count-1))
            {
                MessageBox.Show("리스트의 마지막 곡 입니다.");
            }
            else if (randomCheck == 1)
            {
                MessageBox.Show("한 곡 재생 입니다.");
            }
            else
            {
                WMP.controls.next();    //다음 곡 이동
                playIndex++;    //현재 재생중인 인덱스 증가
                choiceLabel.Text = "♬ " + playList.Items[playIndex].SubItems[0].Text + "-" + playList.Items[playIndex].SubItems[1].Text;
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            int index= playList.FocusedItem.Index;

            if (index == playIndex) //재생중인 곡을 삭제한다면
                MessageBox.Show("현재 재생중인 곡은 삭제할 수 없습니다.");
            else
            {
                playList.FocusedItem.Remove();
            }       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FileDownPath=null;   //한 곡 경로

            if (comboBox1.SelectedItem.Equals("한곡 재생"))
            {
                if (playList.SelectedIndices.Count==0)
                {   //곡선택이 안되어 있을 때
                    MessageBox.Show("반복 할 음악을 선택하세요");
                    comboBox1.SelectedIndex=0;
                    return;
                }

                newPlayList = WMP.newPlaylist("MusicPlayer", "");
                int index;
                index = playList.FocusedItem.Index;
                oneSongIndex = index;
                string musicName = playList.Items[index].SubItems[0].Text;

                DirectoryInfo d = new DirectoryInfo(downPath);    //디렉토리 경로

                FileInfo[] fArray = d.GetFiles();        //디렉토리 해당 mp3 파일 배열
                folder = shell.NameSpace(downPath);  //디렉토리 해당 파일 속성 가져오기

                foreach (FileInfo fInfo in fArray)  //파일 정보 ListView에 저장
                {
                    FolderItem mp3file = folder.ParseName(fInfo.Name);  //파일 이름
                    if (folder.GetDetailsOf(mp3file, 21).ToString() == musicName)
                        FileDownPath = fInfo.FullName;
                }
                IWMPMedia Media;
                Media = WMP.newMedia(@FileDownPath);  //새로운 음악파일 객체 생성    
                newPlayList.appendItem(Media);        //플레이리스트에 추가
                randomCheck = 1;  //구별할 수 있도록 1저장
            }
            else
            {
                randomCheck = 0;    //설정 안할 때
            }
        }

        
    }
}
