using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Echecs.reseau
{
    class Server
    {
        Server()
        {
            TcpListener tcpListener = new TcpListener(8000);
            tcpListener.Start();
            Socket socketForClient = tcpListener.AcceptSocket();
            if (socketForClient.Connected)
            {
                Console.WriteLine("Client connected");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                System.IO.StreamWriter streamWriter =
                new System.IO.StreamWriter(networkStream);
                System.IO.StreamReader streamReader =
                new System.IO.StreamReader(networkStream);
                string theString = "Sending";
                streamWriter.WriteLine(theString);
                Console.WriteLine(theString);
                streamWriter.Flush();
                theString = streamReader.ReadLine();
                Console.WriteLine(theString);
                streamReader.Close();
                networkStream.Close();
                streamWriter.Close();

            }
        }
    }
}
