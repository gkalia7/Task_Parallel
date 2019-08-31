using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Parallel
{
    class WaitingForTheTimeToPass
    {
        public static void WaitHandleCustomTimeMethod()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
           {
               int i = 0;
               Console.WriteLine("Press any key to diffuse: you have only 5 seconds to take an action");
               bool cancelled = token.WaitHandle.WaitOne(5000);

               Console.WriteLine(cancelled ? "Disarmed" : "Boom!");
           }, token);

            t.Start();

            Console.ReadKey();
            cts.Cancel();

        }
    }
}
