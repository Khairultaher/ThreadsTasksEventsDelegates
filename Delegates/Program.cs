using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateExample delexample = new DelegateExample();
            delexample.LogRunningProc(CallBackMethod);
            Console.ReadLine();
        }

        static void CallBackMethod(int num)
        {
            Console.WriteLine(num);
        }
    }

    public class DelegateExample
    {
        public delegate void CallBackDel(int num);
        public void LogRunningProc(CallBackDel callBack)
        {
            for (int i = 0; i < 100; i++)
            {
                callBack(i + 1);
            }
        }
    }
}
