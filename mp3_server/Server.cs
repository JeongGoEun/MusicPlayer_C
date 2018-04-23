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

namespace mp3_server
{
    public partial class Server : Form
    {
        /*서버, 통신*/
        const int PORT = 7000;  //포트번호
        const string IP = "192.168.230.1";  //IP
        private NetworkStream m_NetStream;  //네트워크 스트림
        private TcpListener m_Listener; //리스너
        private byte[] sendBuffer = new byte[1024 * 4]; //스트림에 보내는 단위.버퍼
        private byte[] sendBuffer2 = new byte[1024 * 2];    //파일을 읽는 단위.버퍼
        private byte[] readBuffer = new byte[1024 * 4];     //스트림을 받는 단위.버퍼
        private bool m_blsCientOn = false;
        private Thread m_Thread;
        public MusicName MusicNameClass;    //패킷 클래스

        /*파일,디렉토리*/
        string path;    //Directory Path
        DirectoryInfo d;    //Directory정보
        ShellClass shell = new ShellClass();    //mp3속성
        ListViewItem item;
        FileInfo[] fArray;  //File정보
        Folder folder;


        public Server()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_IP.Text = IP;
            txt_Port.Text= Convert.ToString(PORT);
            this.m_Thread = new Thread(new ThreadStart(RUN));
            this.m_Thread.Start();
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (musicList.Items.Count != 0) //경로 다시 지정
                {
                    musicList.Items.Clear();
                }
                else  //ListView로 파일 정보 로드
                {
                    try
                    {
                        path = folderBrowserDialog1.SelectedPath;
                        this.pathTxt.Text = path;
                        d = new DirectoryInfo(path);    //디렉토리 경로

                        fArray = d.GetFiles("*.mp3");          //디렉토리 해당 mp3 파일 배열
                        folder = shell.NameSpace(path);  //디렉토리 해당 파일 속성 가져오기

                        foreach (FileInfo fInfo in fArray)  //파일 정보 ListView에 저장
                        {
                            FolderItem mp3file = folder.ParseName(fInfo.Name);

                            item = musicList.Items.Add(folder.GetDetailsOf(mp3file, 21));
                            item.SubItems.Add(folder.GetDetailsOf(mp3file, 20));
                            item.SubItems.Add(folder.GetDetailsOf(mp3file, 27));
                            item.SubItems.Add(folder.GetDetailsOf(mp3file, 28));
                        }
                    }
                    catch
                    {
                        MessageBox.Show("파일 불러오기 에러");
                    }
                }
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
           
            if (pathTxt.Text.CompareTo("") == 0)    //path 비어있다면 에러
            {
                DialogResult dr = MessageBox.Show("경로지정", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate () { startBtn.Text = "Stop"; }));
                this.Invoke(new MethodInvoker(delegate () { stateTxt.AppendText("Server - Start\n"); }));
                this.Invoke(new MethodInvoker(delegate () { stateTxt.AppendText("Storage Path : " + path + "\n"); }));
                this.Invoke(new MethodInvoker(delegate () { stateTxt.AppendText("waiting for client access...\n"); }));
            }
        }

        public void RUN()
        {
            this.m_Listener = new TcpListener(PORT);
            this.m_Listener.Start();
            MusicName MusicInfo = new MusicName();
            MusicInfo.Type = (int)PacketType.SendToClient;

            Socket Client = this.m_Listener.AcceptSocket();

            if (Client.Connected) //client 처음에 listView 데이터 보냄
            {
                m_blsCientOn = true;
                this.Invoke(new MethodInvoker(delegate () { stateTxt.AppendText("Client Access !!\n"); }));
                this.m_NetStream = new NetworkStream(Client);

                foreach (FileInfo fInfo in fArray)  //파일 정보 ListView에 저장
                {
                    FolderItem mp3file = folder.ParseName(fInfo.Name);

                    MusicInfo.musicName = (folder.GetDetailsOf(mp3file, 21));
                    MusicInfo.artistName = (folder.GetDetailsOf(mp3file, 20));
                    MusicInfo.musicTime = (folder.GetDetailsOf(mp3file, 27));
                    MusicInfo.bitRate = (folder.GetDetailsOf(mp3file, 28));
                    MusicInfo.path = this.path;

                    Packet.Serialize(MusicInfo).CopyTo(sendBuffer, 0);  //send buffer로 복사
                    this.Send();    //NetStream으로 복사
                }
            }

            int nRead = 0;
            while (this.m_blsCientOn)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_NetStream.Read(this.readBuffer, 0, readBuffer.Length);
                    
                }
                catch
                {
                    this.m_blsCientOn = false;
                    this.m_NetStream = null;
                }
                
                Packet packet = (Packet)Packet.Deserialize(readBuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.SendToServer:  //클라이언트가 원하는 파일 얻어오기
                        {
                            string filePath=null;
                            ClientRequest request = (ClientRequest)Packet.Deserialize(readBuffer);  //클라이언트에 파일 보내기위한 desirialize
                            MusicName musicInfo = new MusicName();  //클라이언트 플레이 리스트 추가

                            musicInfo.Type = (int)PacketType.서버음악정보;
                            string clientMusic = request.musicName; //클라이언트가 원하는 음악 제목
                            int i = 0;
                            this.Invoke(new MethodInvoker(delegate () { stateTxt.AppendText("Download Request !!\n"); }));
                            
                            foreach (FileInfo fInfo in fArray)  //파일 정보 ListView에 저장
                            {
                                FolderItem mp3file = folder.ParseName(fInfo.Name);
                                if (folder.GetDetailsOf(mp3file, 21).Equals(clientMusic))   //클라이언트 요청한 파일 확인
                                {
                                    filePath = fArray[i].FullName;
                                    musicInfo.musicName = (folder.GetDetailsOf(mp3file, 21));
                                    musicInfo.artistName = (folder.GetDetailsOf(mp3file, 20));
                                    musicInfo.musicTime = (folder.GetDetailsOf(mp3file, 27));
                                    musicInfo.bitRate = (folder.GetDetailsOf(mp3file, 28));
                                    musicInfo.path = this.path;
                                }
                                else
                                {
                                    i++;
                                }                             
                            }
                            this.Invoke(new MethodInvoker(delegate () { stateTxt.AppendText("Send File : " + filePath + "\n"); }));

                            FileInfo fileInfo= new FileInfo(filePath);  //서버 상태 텍스트에 추가 할 해당 파일 정보
                            ClientFile cFile = new ClientFile();    //서버의 파일을 보내기 위한 패킷
                            FileStream fi = new FileStream(filePath,FileMode.Open,FileAccess.Read); //클라이언트가 원하는 파일 열고 읽기
                            
                            cFile.FileName = fileInfo.Name;       //파일 이름
                            cFile.FileNameLegth = fi.Name.Length;  //파일 이름 사이즈
                            cFile.FileSize = (int)fi.Length;    //파일 사이즈

                            int count = (int)fi.Length/(1024*2);    // 파일 전체 크기/읽는 크기

                            cFile.FileCount = count+1;  //파일 읽는 전체 count

                            for (int j = 0; j < count; j++)
                            {
                                fi.Read(cFile.FileData, 0, 1024 * 2);
                                cFile.Type = (int)PacketType.ReceiveToServer;
                                Packet.Serialize(cFile).CopyTo(sendBuffer, 0);  //send buffer로 복사
                                this.Send();    //NetStream으로 복사*/
                            }

                            fi.Read(cFile.FileData, 0, 1024 * 2);   //마지막 남은 스트림 보내기
                            cFile.Type = (int)PacketType.ReceiveToServer;
                            Packet.Serialize(cFile).CopyTo(sendBuffer, 0);  //send buffer로 복사
                            this.Send();    //NetStream으로 복사*/


                            Packet.Serialize(musicInfo).CopyTo(sendBuffer, 0);  //파일 전송 끝나면 클라이언트 플레이 리스트에 추가
                            this.Send();    //NetStream으로 복사
                        }
                        break;
                }
            }
        }
        public void Send()
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();
            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_blsCientOn = false;
            this.m_Listener.Stop();
            this.m_NetStream.Close();
            this.m_Thread.Abort();
        }
    }
 }

