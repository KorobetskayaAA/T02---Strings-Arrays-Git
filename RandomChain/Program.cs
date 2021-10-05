using System;

namespace RandomChain
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintRandom();
            PrintRandom();
            PrintRandom();
        }

        static void PrintRandom()
        {
            var seed = 123;
            var n = 100;
            var random = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                Console.Write(random.Next(1000) + "; ");
            }
            Console.WriteLine();
        }
    }
}
