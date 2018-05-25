using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileSerialization;
namespace Server
{
    class Server :IDisposable
    {
        private static String address = "127.0.0.1";
        private static int defaultPort = 13000;
        private ISerialization serialization;

        private const int SIZE = 256;
        private const int BUGGER_SIZE_LENGTH = 32;

        private Int32 port;
        private IPAddress serverAddress;
        private TcpListener server;
        public Server() {
            server = new TcpListener(IPAddress.Parse(address), defaultPort);
            serialization = new Serialization();
            server.Start();

        }

        public void listen()
        {
            while (true)
            {
                Console.WriteLine("Waiting..");
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(() => handle(client));
                clientThread.Start();
            }
        }

        void handle(TcpClient client)
        {
            byte[] bytes = new byte[BUGGER_SIZE_LENGTH];
            Console.WriteLine("Connected");
            NetworkStream stream = client.GetStream();

            FileSender fileSender = serialization.readStream(stream);
            File.WriteAllBytes(fileSender.Name, fileSender.SerializedFile);
            Console.WriteLine("File successfully copied");
            stream.Close();
            client.Close();

        }

        public void Dispose()
        {
            server.Stop();
        }
    }
}
