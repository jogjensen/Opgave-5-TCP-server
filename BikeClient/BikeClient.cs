using BikeServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;

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

            Bike bike = new Bike("Yellow",1000,10,true);

            String json = JsonConvert.SerializeObject(bike);

            sw.WriteLine("Gem");
            sw.WriteLine(json);

            sw.Flush();

            


        }
    }
}
