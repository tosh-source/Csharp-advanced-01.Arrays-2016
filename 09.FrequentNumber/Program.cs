using System;
using System.Linq;

namespace _09.FrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/09.%20Frequent%20number/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            int[] nArray = new int[n];
            ParseValuesToArray(n, nArray);
            int[] repeatingNumbs = new int[n];
            int[] repeatedTimesValue = new int[n];
            int counter = 1;
            int repeatedIndex = 0;
            //calc
            Array.Sort(nArray);

            for (int i = 1; i < n; i++)
            {
                if (nArray[i] == nArray[i - 1])
                {
                    repeatingNumbs[repeatedIndex] = nArray[i];
                    counter++;
                    repeatedTimesValue[repeatedIndex] = counter;
                }
                else
                {
                    counter = 1;
                    repeatedIndex++;
                }
            }
            //print
            int maxRepeatedTimes = repeatedTimesValue.Max();
            int numberToPrint = 0;
            int timesToPrint = 0;
            for (int i = 0; i < repeatedTimesValue.Length; i++)
            {
                if (maxRepeatedTimes == repeatedTimesValue[i])
                {
                    numberToPrint = repeatingNumbs[i];
                    timesToPrint = repeatedTimesValue[i];
                }
            }

            Console.WriteLine(numberToPrint + " ({0} times)", timesToPrint);
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
