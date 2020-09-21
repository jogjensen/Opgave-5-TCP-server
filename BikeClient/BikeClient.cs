using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace BikeClient
{
    public class BikeClient
    {

        public void Start()
        {
            // client opretter forbindelse til server, der ligger på 'localhost' og port 7
            TcpClient socket = new TcpClient("localhost", 4646);

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());


            String strSomSendes = "HentAlle";
            sw.WriteLine(strSomSendes);
            sw.Flush();

            String strRetur = sr.ReadLine();
            Console.WriteLine($"Tilbage fra Server : {strRetur}");


        }
    }
}
