using System;

namespace _06.MaximalKsum
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/06.%20Maximal%20K%20sum/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] nAsArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                nAsArr[i] = int.Parse(Console.ReadLine());
            }
            //calc
            Array.Sort(nAsArr);
            int toPrint = 0;
            for (int i = n - 1; i >= n - k; i--)
            {
                toPrint += nAsArr[i];
            }
            Console.WriteLine(toPrint);
        }
    }
}
