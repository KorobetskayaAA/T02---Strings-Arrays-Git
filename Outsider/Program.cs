using System;
using System.Linq;

namespace Outsider
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = 25;
            double friendshipRate = 0.2;

            var friends = GenerateFriends(guestsCount, friendshipRate);
            bool[,] friendshipMatrix = new bool[guestsCount, guestsCount];
            for (int g = 0; g < friends.Length; g++)
            {
                for (int f = 0; f < friends[g].Length; f++)
                {
                    friendshipMatrix[g, friends[g][f]] = true;
                }
            }

            PrintFriends(friends);
            PrintFriendshipMatrix(friendshipMatrix);
            PrintOutsiders(friendshipMatrix);
        }

        static int[][] GenerateFriends(int length, double friendshipRate)
        {
            Random random = new Random(2);
            int[][] friends = new int[length][];
            for (var i = 0; i < length; i++)
            {
                int friendsCount = (int)(1 + friendshipRate * length * random.NextDouble());
                friends[i] = new int[friendsCount];
                for (var j = 0; j < friendsCount; j++)
                {
                    friends[i][j] = random.Next(length);
                }
            }
            return friends.Distinct().ToArray();
        }

        static void PrintFriends(int[][] friends)
        {
            for (int i = 0; i < friends.Length; i++)
            {
                Console.WriteLine("Друзья {0}-того гостя: {1}", i, string.Join("; ", friends[i]));
            }
        }

        static void PrintFriendshipMatrix(bool[,] matrix)
        {
            Console.CursorLeft = 4;
            for (int f = 0; f <= matrix.GetUpperBound(1); f++)
            {
                Console.Write("{0,3}", f);
            }
            Console.WriteLine();
            for (int g = 0; g <= matrix.GetUpperBound(0); g++)
            {
                Console.Write("{0,3}", g);
                for (int f = 0; f <= matrix.GetUpperBound(1); f++)
                {
                    Console.Write("{0,3}", matrix[g, f] ? "+" : "-");
                }
                Console.WriteLine();
            }
        }

        static void PrintOutsiders(bool[,] matrix)
        {
            Console.Write("Посторонние: ");
            for (int f = 0; f <= matrix.GetUpperBound(1); f++)
            {
                int friendOfCount = 0;
                for (int g = 0; g <= matrix.GetUpperBound(0); g++)
                {
                    if (matrix[g, f])
                    {
                        friendOfCount++;
                    }
                }
                if (friendOfCount == 0)
                {
                    Console.Write(f + "; ");
                }
            }
            Console.WriteLine();
        }
    }
}
