using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Parallel
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Main Program Ended");
            Console.ReadKey();
        }

        /// <summary>
        /// Composite Token System
        /// </summary>
        private static void CompositeCancellationToken()
        {
            var planned = new CancellationTokenSource();
            var preventive = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, preventive.Token, emergency.Token);

            paranoid.Token.Register(() =>
            {
                Console.WriteLine("Cancellation has been requested");
            });

            Task.Factory.StartNew(() =>
            {
                int i = 0;


                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++} \t");

                    Thread.Sleep(1000);
                }

                paranoid.Token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle has been released, cancellation was requested");


            }, paranoid.Token);

            Console.ReadKey();
            preventive.Cancel();
        }

        /// <summary>
        /// Method to cancel the task
        /// </summary>
        private static void CancellationTokenRegister()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(() =>
            {
                Console.WriteLine("Cancellation has been requested");
            }
                );

            var t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++} \t");
                }
            }
            , token);
            t.Start();

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle has been released, cancellation was requested.");
            });

            Console.ReadKey();
            cts.Cancel();
        }
    }
}
