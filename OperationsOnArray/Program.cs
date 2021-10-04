using System;

namespace OperationsOnArray
{
    /* АНТИпример:
     * Почему массивы используют как неизменяемый тип данных?
     */
    class Program
    {
        static void Main(string[] args)
        {
            ManageArray();
        }

        static void ManageArray()
        {
            var arr = new int[0];
            for (; ; )
            {
                Console.Clear();
                ShowMenu();
                PrintArray(arr);
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Q: return;
                    case ConsoleKey.R:
                        Console.Clear();
                        Console.WriteLine("ЗАМЕНА ЗНАЧЕНИЯ В УКАЗАННОЙ ПОЗИЦИИ");
                        ArrayReplace(arr, ReadPosition(arr.Length - 1), ReadNewValue());
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine("ДОБАВЛЕНИЕ НОВОГО ЗНАЧЕНИЯ В КОНЕЦ МАССИВА");
                        arr = ArrayAdd(arr, ReadNewValue()); 
                        break;
                    case ConsoleKey.I:
                        Console.Clear();
                        Console.WriteLine("ВСТАВКА НОВОГО ЗНАЧЕНИЯ В УКАЗАННУЮ ПОЗИЦИЮ");
                        arr = ArrayInsert(arr, ReadPosition(arr.Length - 1), ReadNewValue()); 
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine("УДАЛЕНИЕ ЗНАЧЕНИЯ В УКАЗАННОЙ ПОЗИЦИИ");
                        arr = ArrayRemove(arr, ReadPosition(arr.Length - 1)); 
                        break;
                    case ConsoleKey.G:
                        Console.Clear();
                        Console.WriteLine("ГЕНЕРАЦИЯ МАССИВА");
                        arr = ArrayGenerate(ReadLength());
                        break;
                }
            }
        }

        static void ArrayReplace(int[] array, int position, int value)
        {
            array[position] = value;
        }

        static int[] ArrayAdd(int[] array, int value)
        {
            var newArray = new int[array.Length + 1];
            newArray[array.Length] = value;
            Array.ConstrainedCopy(array, 0, newArray, 0, array.Length);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    newArray[i] = array[i];
            //}
            return newArray;
        }

        static int[] ArrayInsert(int[] array, int position, int value)
        {
            var newArray = new int[array.Length + 1];
            newArray[position] = value;
            if (position > 0)
                Array.ConstrainedCopy(array, 0, newArray, 0, position);
            if (position < array.Length - 1)
                Array.ConstrainedCopy(array, position, newArray, position + 1, array.Length - position);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    newArray[i < position ? i : i + 1] = array[i];
            //}
            return newArray;
        }

        static int[] ArrayRemove(int[] array, int position)
        {
            var newArray = new int[array.Length - 1];
            if (position > 0)
                Array.ConstrainedCopy(array, 0, newArray, 0, position);
            if (position < array.Length - 1)
                Array.ConstrainedCopy(array, position + 1, newArray, position, array.Length - position - 1);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (i != postion)
            //        newArray[i < position ? i : i - 1] = array[i];
            //}
            return newArray;
        }

        static int[] ArrayGenerate(int length)
        {
            var newArray = new int[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                newArray[i] = random.Next();
            }
            return newArray;
        }

        static int ReadPosition(int maxValue)
        {
            int position;
            Console.WriteLine("Введите индекс значения в массиве: ");
            while (!int.TryParse(Console.ReadLine(), out position) 
                || position < 0 || position > maxValue)
            {
                Console.Error.WriteLine("Введите целое число в диапазоне от 0 до " + maxValue);
            }
            return position;
        }

        static int ReadNewValue()
        {
            int position;
            Console.WriteLine("Введите значение: ");
            while (!int.TryParse(Console.ReadLine(), out position))
            {
                Console.Error.WriteLine("Введите целое число");
            }
            return position;
        }

        static int ReadLength()
        {
            int length;
            Console.WriteLine("Введите длину массива: ");
            while (!int.TryParse(Console.ReadLine(), out length) && length > 0)
            {
                Console.Error.WriteLine("Введите целое положительное число");
            }
            return length;
        }

        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.CursorLeft = 0;
            PrintMenuCommand("Q", "Выход");
            PrintMenuCommand("R", "Заменить");
            PrintMenuCommand("A", "Добавить");
            PrintMenuCommand("I", "Вставить");
            PrintMenuCommand("D", "Удалить");
            PrintMenuCommand("G", "Сгенерировать");
            Console.WriteLine();
            Console.ResetColor();
        }

        static void PrintMenuCommand(string key, string action)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" " + action + " ");
        }

        static void PrintArray(int[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("[{0}] = {1}", i, arr[i]);
            }
        }
    }
}
