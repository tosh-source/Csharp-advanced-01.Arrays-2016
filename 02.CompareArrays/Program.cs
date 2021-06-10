using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CompareArrays
{
    class Program
    {
        static void Main()
        {  //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/02.%20Compare%20arrays/README.md

            int n = int.Parse(Console.ReadLine());
            long[] firstArr = new long[n];
            for (int i = 0; i < n; i++)
            {
                firstArr[i] = long.Parse(Console.ReadLine());
            }

            long[] secondArr = new long[n];
            for (int i = 0; i < n; i++)
            {
                 secondArr[i] = long.Parse(Console.ReadLine());
            }
               
            bool equal = true;
            for (int i = 0; i < n; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    continue;
                }
                else
                {
                    equal = false;
                }
            }
            Console.WriteLine(equal ? "Equal" : "Not equal");
        }
    }
}
