﻿using System;

namespace BikeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            BikeServerWorker worker = new BikeServerWorker();

            worker.Start();

            Console.ReadLine();
        }
    }
}
