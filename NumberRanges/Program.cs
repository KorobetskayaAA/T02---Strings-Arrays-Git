using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NumberRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 30;
            int min = 1;
            int max = 20;
            Random random = new Random();
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(min, max);
            }

            Console.WriteLine(string.Join(", ", numbers));

            numbers = numbers.Distinct().ToArray();
            Array.Sort(numbers);
            Console.WriteLine(string.Join(", ", numbers));

            int rangeStart = numbers[0];
            int rangeEnd = rangeStart;
            StringBuilder ranges = new StringBuilder(rangeStart.ToString());
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == rangeEnd + 1)
                {
                    rangeEnd = numbers[i];
                }
                else
                {
                    if (rangeEnd > rangeStart)
                    {
                        ranges.Append($"-{rangeEnd}");
                    }
                    rangeStart = rangeEnd = numbers[i];
                    ranges.Append($", {rangeStart}");
                }
            }
            if (rangeEnd > rangeStart)
            {
                ranges.Append($"-{rangeEnd}");
            }

            Console.WriteLine(ranges);
        }
    }
}
