using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRunVsTaskFactoryStartNew
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() =>
             {
                 Task inner = Task.Factory.StartNew(() => { });
                 return inner;
             });

            var t2 = Task.Factory.StartNew(() =>
             {
                 Task<int> inner = Task.Factory.StartNew(() => 42);
                 return inner;
             });

            var t3 = Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            });

            var t4 = Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }).Unwrap();

            var t5 = Task.Run(async delegate
            {
                await Task.Delay(1000);
                return 42;
            });
            var t5_1 = Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap();


            int res1 = await Task.Run(async () =>
            {
                await Task.Delay(1000);
                return 42;
            });


            int res2 = await Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap();

            int res3 = await await Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            Console.ReadLine();
        }
    }
}
