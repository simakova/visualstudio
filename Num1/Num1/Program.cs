using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num1
{
    class Program
    {
        static void Main()
        {
            int sum=0, num;
            Console.WriteLine("Задача 1924. Четыре чертенка");
            Console.Write("Введите целое число (от 1 до 50): ");
            String n = Console.ReadLine();
            num = Convert.ToInt32(n);
            for (int i = 0; i <= num; i++)
                sum = sum + i;
            if (sum%2 == 1) Console.WriteLine("grimy");
           // else if (sum == 0) Console.WriteLine("nobody");
            else Console.WriteLine("Ответ: black");
        }
    }
}
