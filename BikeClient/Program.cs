using System;

namespace BikeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BikeClient worker = new BikeClient();

            worker.Start();

            Console.ReadLine();
        }
    }
}
