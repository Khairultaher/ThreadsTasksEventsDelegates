﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStartTaskRunStartNew
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CustomerRepository repository = new CustomerRepository();
            var maleCustomers = new List<Customer>();
            var femaleCustomers = new List<Customer>();



            #region Sync Call
            var start = DateTime.Now;
            repository.RunProcess("Sync Call 1");
            repository.RunProcess("Sync Call 2");

            var end = DateTime.Now;
            TimeSpan totalTime = end.Subtract(start);
            Console.WriteLine($"Sync Call takes : {totalTime.TotalSeconds}");
            #endregion

            Console.WriteLine($"================================================");
           
            #region Async Call
            start = DateTime.Now;

            var async1 =  repository.RunProcessAsync("Async Call 1");
            var async2 = repository.RunProcessAsync("Async Call 2");

            await Task.WhenAll(new List<Task> { async1, async2 });
            end = DateTime.Now;
            totalTime = end.Subtract(start);
            Console.WriteLine($"Async Call takes : {totalTime.TotalSeconds}");
            #endregion

            Console.WriteLine($"================================================");
           
            #region Call with Task.Factory.StartNew
            start = DateTime.Now;

            var task1 = Task.Factory.StartNew(() => {
                repository.RunProcess("Call with Task.Factory.StartNew 1"); 
            });
            var task2 = Task.Factory.StartNew(() => {
                repository.RunProcess("Call with Task.Factory.StartNew 2");
            });

            await Task.WhenAll(new List<Task> { task1, task2 });

            end = DateTime.Now;
            totalTime = end.Subtract(start);
            Console.WriteLine($"Call with Task.Factory.StartNew takes : {totalTime.TotalSeconds}");
            #endregion

            Console.WriteLine($"================================================");
           
            #region Call with new Thread
            start = DateTime.Now;

            var thread1 = new Thread(() => {
                repository.RunProcess("Call with new Thread 1");
            });
            thread1.Start();

            var thread2 = new Thread(() => {
                repository.RunProcess("Call with new Thread 2");
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            end = DateTime.Now;
            totalTime = end.Subtract(start);
            Console.WriteLine($"Call with new Thread takes : {totalTime.TotalSeconds}");
            #endregion

            Console.ReadLine();
        }
    }

    public class CustomerRepository
    {
        private List<Customer> customers;
        public CustomerRepository()
        {
            customers = new List<Customer>
            {
                new Customer(){ Id = 1, Gender = "M", Name = "A"},
                new Customer(){ Id = 2, Gender = "M", Name = "B"},
                new Customer(){ Id = 3, Gender = "M", Name = "C"},
                new Customer(){ Id = 4, Gender = "M", Name = "D"},
                new Customer(){ Id = 5, Gender = "M", Name = "E"},

                new Customer(){ Id = 6, Gender = "F", Name = "F"},
                new Customer(){ Id = 7, Gender = "F", Name = "G"},
                new Customer(){ Id = 8, Gender = "F", Name = "H"},
                new Customer(){ Id = 9, Gender = "F", Name = "I"},
                new Customer(){ Id = 10, Gender = "F", Name = "J"},
            };
        }

        public void RunProcess(string from)
        {

            Thread.Sleep(3000);
            Console.WriteLine($"{from}");
        }

        public async Task RunProcessAsync(string from)
        {
            await Task.Delay(3000);
            Console.WriteLine($"{from}");
        }

        public List<Customer> GetCustomers(string gender) {

            Thread.Sleep(3000);
            return customers.Where(w => w.Gender == gender).ToList();
        }

        public async Task<List<Customer>> GetCustomersAsync(string gender)
        {
            await Task.Delay(3000);
            return customers.Where(w => w.Gender == gender).ToList();
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
    }
}