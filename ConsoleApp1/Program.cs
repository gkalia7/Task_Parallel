using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Parallel
{
    class Program
    {

        public static void Main(string[] args)
        {
            TaskCancellation.CompositeCancellationToken();
            
            Console.WriteLine("Main Program Ended");
            Console.ReadKey();
        }

    }
}
