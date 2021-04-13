using System;
using System.Threading.Tasks;

namespace TaskRunVsAsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MyService myService = new MyService();
            var res1 = await myService.CalculateMandelbrotAsync(); //False asynchronous method
            var res2 = await GetMandelbrotAsync(); // Recommended implementation 
            // OR
            var res3 = await Task.Run(() => myService.CalculateMandelbrot()); // Recommended implementation 

            Console.ReadLine();
        }

        //Called from UI (Recommended implementation)
        public static async Task<int> GetMandelbrotAsync()
        {
            MyService myService = new MyService();
            return await Task.Run(() => myService.CalculateMandelbrot());
        }
    }
    public class MyService
    {
        public int CalculateMandelbrot()
        {
            // Tons of work to do in here!
            for (int i = 0; i != 10000000; ++i) ;
            return 42;
        }

        // A “false asynchronous method” is being created because what it is doing is 
        // wrapping a synchronous method inside another thread (different from the UI).
        public Task<int> CalculateMandelbrotAsync()
        {
            var res = Task.Run(() => CalculateMandelbrot());
            return res;
        }
    }

}
