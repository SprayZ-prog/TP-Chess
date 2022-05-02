using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Echecs.reseau
{
    class Client
    {
        Client()
        {
            TcpClient socketForServer;
            try
            {
                socketForServer = new TcpClient("localHost", 8000);
            }
            catch
            {
                Console.WriteLine(
                "Failed to connect to server at {0}:999", "localhost");
                return;
            }

            NetworkStream networkStream = socketForServer.GetStream();
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            try
            {
                string outputString;
                {
                    outputString = streamReader.ReadLine();
                    Console.WriteLine(outputString);
                    streamWriter.WriteLine("Client Message");
                    Console.WriteLine("Client Message");
                    streamWriter.Flush();
                }
            }
            catch
            {
                Console.WriteLine("Exception reading from Server");
            }
            networkStream.Close();
        }
    }
}
