using System;

namespace _07.SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        { //conditon: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/07.%20Selection%20sort/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            int[] nAsArr = new int[n];
            ParseNumberToArray(n, nAsArr);
            //calc
            SortMethod(n, nAsArr); //sort method will sort "nAsArr" by increasing order
            //print
            Console.WriteLine(string.Join("\n", nAsArr));
        }

        private static void SortMethod(int n, int[] nAsArr)
        {
            int temp = 0;
            for (int index = 0; index < n; index++)
            {
                for (int sortIndex = index; sortIndex < n; sortIndex++)
                {
                    if (nAsArr[index] > nAsArr[sortIndex])
                    {
                        temp = nAsArr[index];
                        nAsArr[index] = nAsArr[sortIndex];
                        nAsArr[sortIndex] = temp;
                    }
                }
            }
        }

        private static void ParseNumberToArray(int n, int[] nAsArr)
        {
            for (int i = 0; i < n; i++)
            {
                nAsArr[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
