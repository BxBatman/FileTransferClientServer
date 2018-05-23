using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1200);
            Console.WriteLine("Try to connect to server");
            NetworkStream networkStream = client.GetStream();
            Console.WriteLine("Connected");
            while (true)
            {
                string ch = Console.ReadLine();
                byte[] message = Encoding.Unicode.GetBytes(ch);
                networkStream.Write(message, 0, message.Length);
                Console.WriteLine("Sent");
            }
            client.Close();
            Console.ReadLine();

        }
    }
}
