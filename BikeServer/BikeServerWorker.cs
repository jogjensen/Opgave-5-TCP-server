using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BikeServer
{
    public class BikeServerWorker
    {
        #region Listen

        //Create list
        private static readonly List<Bike> bikes = new List<Bike>
        {
            new Bike("Yellow", 1000, 17, true),
            new Bike("Brown", 10, 3, false),
            new Bike("Black", 5, 4, false),
            new Bike("White", 1000, 20, true)
        };

        #endregion

        public void Start()
        {
            var server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            while (true)
            {
                var socket = server.AcceptTcpClient();


                Task.Run(() =>
                {
                    var tempSocket = socket;
                    doClient(tempSocket);
                });
            }
        }


        public void doClient(TcpClient socket)
        {
            var sr = new StreamReader(socket.GetStream());
            var sw = new StreamWriter(socket.GetStream());

            var str = sr.ReadLine();
            Console.WriteLine($"Her er server input: {str}");

            if (str == "HentAlle")
            {
                sw.WriteLine($"Bikes in list: ");
                Console.WriteLine($"Cykler i listen: ");
                foreach (var bikes in bikes) sw.WriteLine(bikes);
                foreach (var bikes in bikes)
                {
                    Console.WriteLine(bikes);
                }
                
            }
            else if (str == "Hent")
            {
                Console.WriteLine("Skriv ID'et på den cykel du ønsker at hente: ");
                sw.WriteLine("Write the ID:  ");

                sw.Flush();

                string str2;
                str2 = sr.ReadLine();
                var i = int.Parse(str2);


                var b = bikes.FirstOrDefault(bikes => bikes.Id == i);

                sw.WriteLine(b);
                Console.WriteLine(b);
            }
           

            sw.Flush();
        }
    }
}