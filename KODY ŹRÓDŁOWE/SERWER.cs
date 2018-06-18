using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace serwer
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("192.168.43.161");

                    TcpListener myList = new TcpListener(ipAd, 8001);

                    myList.Start();

                    Socket s = myList.AcceptSocket();

                    byte[] b = new byte[100];
                    int k = s.Receive(b);

                    Console.WriteLine("\nOTRZYMANO:");
                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));

                    ASCIIEncoding asen = new ASCIIEncoding();

                    Console.WriteLine("\n");

                    s.Close();
                    myList.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("BLAD" + e.StackTrace);
                }
            }
        }
    }
}
  

