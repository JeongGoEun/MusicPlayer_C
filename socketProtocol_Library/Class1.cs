using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace socketProtocol_Library
{
    //하위 버전과의 호환성을 위해서 직렬화되어 온 스트렘이 관계없이 원래 버전으로 만들어줌
    sealed class AllowAllAssemblyVersionDewerializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;
            String currentAssembly = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            assemblyName = currentAssembly;
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            return typeToDeserialize;

            //  throw new NotImplementedException();
        }
    }

    public enum PacketType
    {
        SendToClient=0, //클라이언트로 정보 보내기
        ReceiveToClient,    //클라이언트에서 정보 얻기
        SendToServer,   //서버로 파일 요청하기
        ReceiveToServer, //서버에서 파일 얻어오기
        서버음악정보
        
    }
    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }
        public static byte[] Serialize(Object o)    //개체를 byte로
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();    //읽어서 배열로 배열로 반환
        }

        public static Object Deserialize(byte[] bt) //byte를 개체로
        {
            MemoryStream ms = new MemoryStream(1024 * 4);   
            foreach (byte b in bt)
            {
                ms.WriteByte(b);    //전달 된 byte를 메모리에 쓴다
            }           
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);    //binary formatter로 객체를 만든다.
            ms.Close();            
            return obj; // 그 객체 반환
        }

    }

    [Serializable]
    public class ClientRequest : Packet
    {
        public string musicName;

        public ClientRequest()
        {
            musicName = null;
        }
    }

    [Serializable]
    public class MusicName : Packet
    {/*음악 정보*/
        public string musicName;
        public string artistName;
        public string musicTime;
        public string bitRate;
        public string path;

        public MusicName()
        {
            this.musicName = null;
            this.artistName = null;
            this.musicName = null;
            this.bitRate = null;
            this.path = null;
        }

    }
    [Serializable]
    public class ClientFile :Packet
    {
        public byte[] FileData=new byte[1024*2]; //파일 데이터
        public string FileName; //파일 이름
        public int FileSize;    //파일 크기
        public int FileCount;   //파일 읽는 count
        public ClientFile()
        {
            FileName = null;
            FileSize = 0;
            FileCount = 0;
        }
    }
}
