using System;

namespace FIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine(); //name
            Console.Write("Введите отчество: ");
            string middleName = Console.ReadLine(); //patronymic
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine(); //surname, familyname

            // полностью Имя Отчество Фамилия
            Console.WriteLine(GetFullName(firstName, middleName, lastName));
            // для алфавитного списка - ФАМИЛИЯ И.О.
            Console.WriteLine(GetForList(firstName, middleName, lastName));
            // для генератора логина - фамил_им_отч
            Console.WriteLine(GetForLogin(firstName, middleName, lastName));
        }

        static string GetFullName(string firstName, string middleName, string lastName)
        {
            firstName = ToFirstUpperOtherLower(firstName);
            middleName = ToFirstUpperOtherLower(middleName);
            lastName = ToFirstUpperOtherLower(lastName);
            string fullName = firstName;
            if (!string.IsNullOrEmpty(middleName))
            {
                fullName += " " + middleName; 
            }
            fullName += " " + lastName;
            return fullName;
        }

        static string ToFirstUpperOtherLower(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }

        static string GetForList(string firstName, string middleName, string lastName)
        {
            return lastName.ToUpper() + " " +
                firstName[0].ToString().ToUpper() + "." +
                (string.IsNullOrEmpty(middleName) ? "" : middleName[0].ToString().ToUpper() + ".");
        }

        static string GetForLogin(string firstName, string middleName, string lastName)
        {
            return (
                lastName.Substring(0, Math.Min(5, lastName.Length)) + "_" +
                firstName.Substring(0, Math.Min(2, firstName.Length)) + "_" +
                middleName.Substring(0, Math.Min(3, middleName.Length))
            ).ToLower();
        }
    }
}
