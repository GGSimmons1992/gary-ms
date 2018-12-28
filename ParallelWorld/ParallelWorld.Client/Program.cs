using ParallelWorld.Domain.Models;
using System;

namespace ParallelWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithThreads();
            Console.WriteLine("end of program");
        }

        static void PlayWithThreads()
        {
            var t = new ThreadModel();
            t.ThreadMaster("pro");
        }
    }
}
