using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace Num1
{
    class Program
    {
        static void Main()
        {
            double sum = 0;
            Console.WriteLine("Задача 1924. Четыре чертенка");
            Console.Write("Введите целое число (от 1 до 50): ");
            String n = Console.ReadLine();
            int num = Convert.ToInt32(n);
            for (int i = 0; i <= num; i++)
                sum =+ i;
            if (sum%2 == 0) Console.WriteLine("black");
            else Console.WriteLine("grimy");
//            Console.ReadKey();
        }
    }
}
