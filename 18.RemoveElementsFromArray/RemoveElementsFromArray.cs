using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.RemoveElementsFromArray
{
    class RemoveElementsFromArray
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/18.%20Remove%20elements%20from%20array/README.md
            //input and values
            int n = int.Parse(Console.ReadLine());
            int[] nArray = new int[n];
            for (int i = 0; i <= nArray.Length - 1; i++)
            {
                nArray[i] = int.Parse(Console.ReadLine());
            }

            int[] LIS = new int[n]; //define "Long Increasing Sequence"
            for (int i = 0; i <= LIS.Length - 1; i++)
            {
                LIS[i] = 1;
            }
            //calculation
            for (int masterIndex = 1; masterIndex < n; masterIndex++)
            {
                for (int subIndex = 0; subIndex < masterIndex; subIndex++)
                {
                    if ((nArray[masterIndex] >= nArray[subIndex]) && (LIS[subIndex] >= LIS[masterIndex]))
                    {
                        LIS[masterIndex] = LIS[subIndex] + 1;
                    }
                }
            }
            //print
            Array.Sort(LIS);
            int printResult = n - LIS[LIS.Length - 1];
            Console.WriteLine(printResult);
        }
    }
}