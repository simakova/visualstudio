using System;
using System.Globalization;


namespace Num2
{
    public class Program
    {
        private static void Main()
        {
            string[] numbers = new string[3];
            numbers[0] = Console.ReadLine();
            numbers[1] = Console.ReadLine();
            numbers[2] = Console.ReadLine();
            Console.WriteLine(int.Parse(numbers[0]) - int.Parse(numbers[1]) * int.Parse(numbers[2]));
        }
    }
}

