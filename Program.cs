using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.1.70");
            int port = 3000;
            Client client = new Client(ip, port);
            Console.WriteLine("connected successfully ....");
            Thread.Sleep(500);
            Console.Clear();
            client.ServerData();

            try
            {
                string messageToServer = "";
                string messageFromServer = "";

                while (client.Status)
                {
                    messageToServer = Console.ReadLine();
                    if (messageToServer == "exit")
                    {
                        client.Status = false;
                        client.StreamWriter.WriteLine("bye");
                        client.StreamWriter.Flush();

                    }
                    else
                    {
                        client.StreamWriter.WriteLine(messageToServer);
                        client.StreamWriter.Flush();

                        messageFromServer = client.StreamReader.ReadLine();
                        Console.WriteLine("server : " + messageFromServer);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
