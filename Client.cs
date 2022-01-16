using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public class Client
    {
        public IPAddress MyIP { get; private set; }
        public int Port { get; private set; }
        public bool Status = true;
        public TcpClient TcpClient { get; set; }
        public NetworkStream NetworkStream { get; set; }
        public StreamReader StreamReader { get; set; }
        public StreamWriter StreamWriter { get; set; }
        public Socket ServerSocket { get; set; }

        public Client(IPAddress iPAddress, int port)
        {
            MyIP = iPAddress;
            Port = port;
        }

        public void ConnectToServer()
        {
            try
            {
                TcpClient = new TcpClient(MyIP.ToString(), Port);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ServerData()
        {
            NetworkStream = TcpClient.GetStream();
            StreamReader reader = new StreamReader(NetworkStream);
            StreamWriter writer = new StreamWriter(NetworkStream);
        }

        public void Disconnect()
        {
            StreamWriter.Close();
            StreamReader.Close();
            NetworkStream.Close();
            TcpClient.Close();
        }
    }
}
