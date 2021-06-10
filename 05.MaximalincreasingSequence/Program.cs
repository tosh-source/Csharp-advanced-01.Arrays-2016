using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MaximalincreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/05.%20Maximal%20increasing%20sequence/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            long[] maxSequence = new long[n]; //define the sequence
            int[] theNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                theNumbers[i] = int.Parse(Console.ReadLine());
            }
            int maxSeqIndex = 0;
            int maxSeqEqualElements = 1;
            //calc
            for (int i = 1; i < n; i++)
            {
                if (theNumbers[i] > theNumbers[i - 1])
                {
                    maxSeqEqualElements++;
                    maxSequence[maxSeqIndex] = maxSeqEqualElements;
                }
                else
                {
                    maxSeqEqualElements = 1;
                    maxSeqIndex++;
                }
            }
            //print
            Console.WriteLine(maxSequence.Max());
        }
    }
}
