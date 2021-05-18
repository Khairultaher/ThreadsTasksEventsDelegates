using EventsDelegates;
using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var delexample = new DelegateExample();
            // Example: Delegate
            //delexample.LogRunningProc(CallBackMethod);

            // Example: Event
            delexample.Publisher += Subscriber1;
            delexample.Publisher += Subscriber2;
            // delexample.publisher = null; // not possible will throw exception.
            delexample.LogRunningProc();

            Console.ReadLine();
        }
        static void Subscriber1(int num)
        {
            Console.WriteLine($"Subscriber1 {num}");
        }
        static void Subscriber2(int num)
        {
            Console.WriteLine($"Subscriber2 {num}");
        }
        static void CallBackMethod(int num)
        {
            Console.WriteLine(num);
        }
    }
}
