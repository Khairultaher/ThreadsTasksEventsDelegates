using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateExample delexample = new DelegateExample();

            // Example: Delegate
            //delexample.LogRunningProc(CallBackMethod);

            // Example: Event
            delexample.Publisher += Subscriber1;
            delexample.Publisher += Subscriber2;
            // delexample.publisher = null; // not possible will throw exception.
            delexample.LogRunningProc();

            Console.ReadLine();
        }

        static void CallBackMethod(int num)
        {
            Console.WriteLine(num);
        }

        static void Subscriber1(int num)
        {
            Console.WriteLine($"Subscriber1 {num}");
        }

        static void Subscriber2(int num)
        {
            Console.WriteLine($"Subscriber2 {num}");
        }
    }

    public class DelegateExample
    {
        public delegate void CallBackDel(int num);
        public event CallBackDel Publisher = null;
        public void LogRunningProc(CallBackDel callBack)
        {
            for (int i = 0; i < 100; i++)
            {
                callBack(i + 1);
            }
        }

        public void LogRunningProc()
        {
            for (int i = 0; i < 100; i++)
            {
                Publisher(i + 1);
            }
        }

        public int Abc(int a, int b)
        {
            return a + b;
        }
        public int Abc(int a, int b, int c)
        {
            return a + b + c;
        } 
        public string  Abc(string a, string b)
        {
            return a + b;
        }

        //public int Abc(string a, string b)
        //{
        //    return 1;
        //}
    }
}
