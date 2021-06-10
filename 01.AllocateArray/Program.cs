using System;
using System.Collections.Generic;
using System.Linq;


namespace _01.AllocateArray
{
    class Program
    {
        static void Main()
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/01.%20Allocate%20array/README.md

            int n = int.Parse(Console.ReadLine());
            int[] arrOfN = new int[n];
            for (int i = 0; i < arrOfN.Length; i++)
            {
                arrOfN[i] = i * 5;
            }
            Console.WriteLine(string.Join("\n", arrOfN));
        }
    }
}
