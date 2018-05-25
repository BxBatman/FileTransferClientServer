using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace Server
{
    class Program
    {
       
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server();
                server.listen();
            }catch(SocketException e)
            {
                Console.WriteLine("SocketException!",e);

            }

            Console.WriteLine("Hit enter to continure");
            Console.Read();

        }

        
    }
}
