using System;
using System.Net.Http;
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

            DateTime dt1 = DateTime.Now;
            await clsSender.LongRunningProcessAsync(1);
            await clsSender.LongRunningProcessAsync(2);
            DateTime dt2 = DateTime.Now;
            TimeSpan diff = dt2 - dt1;
            Console.WriteLine($"First block running synchronously & ended with {diff}");


            dt1 = DateTime.Now;
            new Thread(() =>
            {
                clsSender.LongRunningProcess(3);

            }).Start();

            await Task.Run(() =>
            {
               clsSender.LongRunningProcess(4);
            });

            dt2 = DateTime.Now;
            diff = dt2 - dt1;
            Console.WriteLine($"Second block running in separate thread & ended with {diff}");



            dt1 = DateTime.Now;
            clsSender.LongRunningProcessAsync(5);

            await clsSender.LongRunningProcessAsync(6);

            dt2 = DateTime.Now;
            diff = dt2 - dt1;
            Console.WriteLine($"Third block running asynchronously ended with {diff}");


            Console.WriteLine("Main Thread: "
                       + Thread.CurrentThread.ManagedThreadId.ToString() + " is end");

            Console.ReadLine();
        }
    }

    public class SenderClass
    {
        public void LongRunningProcess(int num)
        {
            DateTime dt1 = DateTime.Now;
            Console.WriteLine($"Long Running Process {num} Started with Thread " 
                + Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(5000);
            // Task.Delay(5000);

            DateTime dt2 = DateTime.Now;
            TimeSpan diff = dt2 - dt1;
            Console.WriteLine($"Long Running Process {num} Ended with " 
                + Thread.CurrentThread.ManagedThreadId.ToString() + $" {diff}");

        }

        public async Task LongRunningProcessAsync(int num)
        {
            DateTime dt1 = DateTime.Now;
            Console.WriteLine($"Long Running Process {num} Started with Thread "
                + Thread.CurrentThread.ManagedThreadId.ToString());

            await Task.Delay(5000);

            //HttpClient httpClient = new HttpClient();
            //var data = await httpClient.GetAsync("https://stackoverflow.com");

            DateTime dt2 = DateTime.Now;
            TimeSpan diff = dt2 - dt1;
            Console.WriteLine($"Long Running Process {num} Ended with "
                + Thread.CurrentThread.ManagedThreadId.ToString() + $" {diff}");

        }
    }
}
