using System;
using System.Linq;

namespace ArrayCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int n = 100;
            var numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = random.Next(100, 200);
            }

            int[] sorted = new int[n];
            numbers.CopyTo(sorted, 0);
            Array.Sort(sorted);

            Console.WriteLine("Array = " + string.Join("; ", numbers));
            Console.WriteLine("Min = " + numbers.Min());
            Console.WriteLine("Max = " + numbers.Max());
            Console.WriteLine("Sum = " + numbers.Sum());
            Console.WriteLine("Avg = " + numbers.Average());
            Console.WriteLine("Sorted = " + string.Join("; ", sorted));
            Console.WriteLine("Distint = " + string.Join("; ", sorted.Distinct()));

        }

    }
}
