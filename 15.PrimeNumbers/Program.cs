using System;
using System.Linq;

namespace _15.PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/tree/master/Topics/01.%20Arrays/homework/15.%20Prime%20numbers
            //input
            int n = int.Parse(Console.ReadLine());
            int[] nArray = new int[n - 1];
            for (int i = 0; i <= nArray.Length - 1; i++)
            {
                nArray[i] = i + 2;
            }

            //calculation
            int currentPrime = 0;
            Calculations(nArray, currentPrime, n);
            //print
            for (int reverse = nArray.Length - 1; reverse >= 0; reverse--)
            {
                if (nArray[reverse] != 0)
                {
                    Console.WriteLine(nArray[reverse]);
                    break;
                }
            }
        }

        static void Calculations(int[] nArray, int currentPrime, int n)
        {
            for (int currentElementIndex = 0; currentElementIndex <= nArray.Length - 1; currentElementIndex++)
            {
                if (nArray[currentElementIndex] != 0)
                {
                    int currentElementValue = nArray[currentElementIndex];
                    if ((currentElementValue * currentElementValue) > n)
                    {
                        break;
                    }
                    //calculating (and parsing "0" to NOT prime numbers)
                    for (int index = (currentElementIndex + currentElementValue); index <= nArray.Length - 1; index += currentElementValue)
                    {
                        nArray[index] = 0;
                    }
                }
            }
        }
    }
}

//TEST 1//
//Input: 15 ("n")
//Output: 13 (the most closer prime to "n"; also, the program calculate all other prime numbers, without print them: 2,3,5,7,11,13)
//////////
//TEST 2//
//Input: 30 ("n")
//Output: 29 (the most closer prime to "n"; also, the program calculate all other prime numbers, without print them: 2,3,5,7,11,13,17,19,23,29)