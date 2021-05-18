using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegates
{
    public class DelegateExample
    {
        public delegate void CallBackDel(int num);
        public event CallBackDel Publisher = null;
        
        public void LogRunningProc()
        {
            for (int i = 0; i < 100; i++)
            {
                Publisher(i + 1);
            }
        }

        public void LogRunningProc(CallBackDel callBack)
        {
            for (int i = 0; i < 100; i++)
            {
                callBack(i + 1);
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
        public string Abc(string a, string b)
        {
            return a + b;
        }

        //public int Abc(string a, string b)
        //{
        //    return 1;
        //}
    }
}
