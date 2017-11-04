using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 3000);
                server.Start();
                TcpClient newClient = server.AcceptTcpClient();
                Console.WriteLine("Nawiazano polaczenie");

                BinaryWriter writer = new BinaryWriter(newClient.GetStream());
                BinaryReader reader = new BinaryReader(newClient.GetStream());

                string text;
                Console.WriteLine("Podaj tekst: ");
                text = Console.ReadLine();
                writer.Write(text);
                Console.WriteLine("Wyslano Tekst");

                Console.WriteLine("Suma znakow ASCII wynosi " + reader.ReadInt16());
            }
            catch (SocketException) { Console.WriteLine("Blad"); }
        }
    }
}
