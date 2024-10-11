using System.Net.Sockets;
using System.Net;

namespace TCP_Server_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 로컬 포트 8080을 Listen
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();

            byte[] buffer = new byte[1024];

            while (true) 
            { 
                // TcpClient Connection 요청을 받아들여
                // 서버에서 새 TcpClient 객체를 생성하여 리턴
                TcpClient client = listener.AcceptTcpClient();

                // TcpClient 객체에서 NetworkStream을 얻어옴
                NetworkStream stream = client.GetStream();

                // 클라이언트가 연결을 끊을 떄까지 데이터 수신
                int nbytes;
                while ((nbytes = stream.Read(buffer, 0, buffer.Length)) > 0) { 
                    // 데이터 그대로 송신
                    stream.Write(buffer, 0, nbytes);
                }
                // 스트림과 TcpClient 객체
                stream.Close();
                client.Close();

                //계속 반복
            }
        }
    }
}
