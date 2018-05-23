using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private TcpListener listener;
        public Server(int port)
        {
            listener = new TcpListener(IPAddress.Any,port);
            Console.WriteLine("Listening...");
            listener.Start();
            loopClients();
        }

        public void loopClients()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                
                Thread t = new Thread(new ParameterizedThreadStart(handleClient));
                t.Start(client);
                
            }
        }

        public void handleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            Console.WriteLine("Client connected");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            while (true)
            {
                int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
                string ch = Encoding.Unicode.GetString(buffer, 0, data);
                Console.WriteLine("Message received: " + ch);
            }
        }
    }
}
