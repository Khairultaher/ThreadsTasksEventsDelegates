using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsTasks
{
    class Program
    {

        static async Task Main(string[] args)
        {
            SenderClass clsSender = new SenderClass();

            Console.WriteLine("Main Thread: " 
                + Thread.CurrentThread.ManagedThreadId.ToString() + " is running");

            await clsSender.LongRunningProcessAsync(1);

            await clsSender.LongRunningProcessAsync(2);

            new Thread(() =>
            {
                clsSender.LongRunningProcess(3);

            }).Start();

            await Task.Run(() =>
            {
               clsSender.LongRunningProcess(4);
            });

            Console.WriteLine("Main Thread: "
                       + Thread.CurrentThread.ManagedThreadId.ToString() + " is end");

            Console.ReadLine();
        }
    }

    public class SenderClass
    {
        public void LongRunningProcess(int num)
        {
            Console.WriteLine($"Long Running Process {num} Started with Thread " 
                + Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(5000);
            // Task.Delay(5000);
            Console.WriteLine($"Long Running Process {num} Ended with " 
                + Thread.CurrentThread.ManagedThreadId.ToString());

        }

        public async Task LongRunningProcessAsync(int num)
        {
            Console.WriteLine($"Long Running Process {num} Started with Thread "
                + Thread.CurrentThread.ManagedThreadId.ToString());
            //Thread.Sleep(5000);
            await Task.Delay(5000);
            Console.WriteLine($"Long Running Process {num} Ended with "
                + Thread.CurrentThread.ManagedThreadId.ToString());

        }
    }
}
