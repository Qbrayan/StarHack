using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a number");
            int n = Convert.ToInt32(Console.ReadLine());
            bool ans1 =isPrime(n);
            var memPrime = isPrime.Memoize();
            Console.WriteLine($"{ans1}");
            Console.WriteLine("Test Case  Present value");
            var ans2 = Class1.Search(new List<int> { 1, 3, 2, 0 }, 2);
            Console.WriteLine($"{ans2}");
            Console.WriteLine("Test Case  Absent value");
            ans2 = Class1.Search(new List<int> { 1, 3, 2, 0 }, 6);
            Console.WriteLine($"{ans2}");
            Console.ReadKey();

        }

        static Func<int,bool> isPrime = number =>
         {
             if (number < 2) return false;
             if (number == 2) return true;
             if (number % 2 == 0) return false;
             for (int l = 3; l * l <= number; l += 2)
                 if (number % l == 0) return false;
             return true;
         };



        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> f)
        {
            var cache = new ConcurrentDictionary<T, TResult>();
            return argument => cache.GetOrAdd(argument, f);
        }
    }
}
