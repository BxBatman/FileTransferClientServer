using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FileSerialization;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client;
            FileSender fileSender;

            client = new Client();

            client.connect();

            String path = "../../test.txt";

            using(FileStream fileStream = File.OpenRead(path))
            {
                String filename = Path.GetFileName(path);
                byte[] data = File.ReadAllBytes(path);
                fileSender = new FileSender(filename, data);
            }

            client.sendFile(fileSender);
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}
