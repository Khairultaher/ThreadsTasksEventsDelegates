using System;

namespace EventsDelegates
{
    class Program
    {

        static void Main(string[] args)
        {
            SenderClass clsSender = new SenderClass();
            clsSender.sender += Receaver1;
            clsSender.sender += Receaver2;
            clsSender.sender += Receaver3;

            //clsSender.sender = null;
            //clsSender.sender -= Receaver2;

            clsSender.RunProces();
            
            Console.ReadLine();
        }

        public static void Receaver1(string val)
        {
            Console.WriteLine("Receaver1 Called " + val);
        }

        public static void Receaver2(string val)
        {
            Console.WriteLine("Receaver2 Called " + val);
        }

        public static void Receaver3(string val)
        {
            Console.WriteLine("Receaver3 Called  " + val);
        }
    }

    public class SenderClass 
    {

        public delegate void Sender(string val );
        public event Sender sender = null;

        public void RunProces() {

            sender("...HI...");
        }

    }
}
