using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Parallel
{
    class Program
    {

        public static void Main(string[] args)
        {
            WaitingForTheTimeToPass.WaitHandleCustomTimeMethod();
            
            Console.WriteLine("Main Program Ended");
            Console.ReadKey();
        }

    }
}
