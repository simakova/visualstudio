using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 1. Раскладываем введенное число N на множители делением на простые числа (массив prime) - получаем новый массив digits
 2. Циклом перебираем массив digits и максимально сворачиваем перемножением элементов (произведение <=10)
 */
namespace Num3
{
    public class Program
    {
        private static void Main()
        {
            int N, Q, count = 4;
            int[] prime = new int[] {2, 3, 5, 7};
            List<int> digits = new List<int>();

            String num = Console.ReadLine();
            N = int.Parse(num);
//1
            for (int i = 0; i <= count; i++)
            {
                while (N%prime[i] == 0)
                {
                    N = N/prime[i];
                    digits.Add(prime[i]);
                }
            }
//2
            
        }
    }
}
