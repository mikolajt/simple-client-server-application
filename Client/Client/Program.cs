using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 3000);
                Console.WriteLine("Nawiazano Polaczenie");

                BinaryWriter writer = new BinaryWriter(client.GetStream());
                BinaryReader reader = new BinaryReader(client.GetStream());

                string text = reader.ReadString();
                Console.WriteLine("Odebrano tekst: " + text);
                byte[] ASCIIbyte = Encoding.ASCII.GetBytes(text);
                int sum = 0;
                foreach (byte b in ASCIIbyte)
                {
                    sum += b;
                }
                writer.Write(sum);
                Console.WriteLine("Wyslano dane: " + sum);

                client.Close();
                Console.WriteLine("Zamknieto polaczenie");
            }
            catch (SocketException) { Console.WriteLine("Blad: Nie udalo sie polaczyc z serwerem"); }
        }
    }
}
