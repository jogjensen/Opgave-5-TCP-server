using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static BikeServer.Bikes;

namespace BikeServer
{
    public class BikeServerWorker
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();
            TcpClient socket = server.AcceptTcpClient();

            while (true)
            {
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    doClient(tempSocket);
                });
            }

        }


        public void doClient(TcpClient socket)
        {
            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());

            String str = sr.ReadLine();
            Console.WriteLine($"Her er server input: {str}");

            if (str == "HentAlle")
            {
                foreach (var bikes in bike)
                {
                    sw.WriteLine(bikes);
                }

            }
            else if (str == "Hent")
            {
                String id = sr.ReadLine();

                int i = Int32.Parse(id);
                

                Bikes b = bike.FirstOrDefault(bikes => bikes.Id == i);

                sw.WriteLine(b);
            }

            sw.Flush();
        }

        #region Listen

        //Create list
        static List<Bikes> bike = new List<Bikes>()
        {
            new Bikes("Yellow",1000,17,true),
            new Bikes("Brown",10,3,false),
            new Bikes("Black",5,4,false),
            new Bikes("White",1000,20,true),

        };
        #endregion


    }
}
