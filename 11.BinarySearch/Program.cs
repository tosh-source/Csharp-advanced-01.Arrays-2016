using System;

namespace _11.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/11.%20Binary%20search/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            int[] nArray = new int[n];
            ParseValuesToArray(n, nArray);
            int x = int.Parse(Console.ReadLine());
            //calc
            int result = Array.BinarySearch(nArray, x);
            if (result < 0)
            {
                result = -1;
            }
            //print
            Console.WriteLine(result);
        }

        private static void ParseValuesToArray(int n, int[] nArray)
        {
            for (int i = 0; i < n; i++)
            {
                nArray[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
