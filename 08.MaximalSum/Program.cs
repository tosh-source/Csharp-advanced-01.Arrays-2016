using System;

namespace _08.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/08.%20Maximal%20sum/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            int[] nArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                nArray[i] = int.Parse(Console.ReadLine());
            }
            //calc
            long currentSum = 0;
            long currentBigSum = 0;
            for (int i = 0; i < n; i++)
            {
                currentSum = currentSum + nArray[i];
                if (currentSum > 0)
                {
                    if (currentSum > currentBigSum)
                    {
                        currentBigSum = currentSum;
                    }
                }
                else //currentSum < 0
                {
                    currentSum = 0; //If less than 0, reset "currentSum" and continue with NEXT index
                }
            }
            Console.WriteLine(currentBigSum);
        }
    }
}
