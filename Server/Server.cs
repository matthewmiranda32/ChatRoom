using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Queue<Message> queue = new Queue<Message>();
        public static Client client;
        TcpListener server;
        
        public Server()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            string message = client.Receive();
            Respond(message);
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
        }
        public void DisplayUserName()
        {
            Dictionary<string, Client> users = new Dictionary<string, Client>();

            TcpClient clientSocket = default(TcpClient);
            Console.WriteLine("Please enter your username: ");
            string username = Console.ReadLine();
            NetworkStream stream = clientSocket.GetStream();
            Client client = new Client(stream, clientSocket);

            foreach (KeyValuePair<string, Client> user in users)
            {
                if (user.Key == username)
                    Console.WriteLine("User: " + user.Key + user.Value);
            }
        }
        //public void ReceiveMessages()
        //{
        //    Message message = new Message(client, );

        //    client.Receive();

        //    queue.Enqueue(message);
        //}
        private void Respond(string body)
        {
             client.Send(body);
        }
    }
}
