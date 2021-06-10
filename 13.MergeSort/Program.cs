using System;

namespace _13.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/13.%20Merge%20sort/README.md
            //input
            int n = int.Parse(Console.ReadLine());
            int[] nArray = new int[n];
            ParseToArray(n, nArray);
            int[] firstArray = new int[n / 2];
            int[] secondArray = new int[n - (n / 2)];
            //fragment array
            FragmentNArrayToFirstArray(n, nArray, firstArray); //with length -> n/2
            FragmentNArrayToSecondArray(n, nArray, secondArray); //with length -> n-(n/2)
            //sort subarrays                                                                 
            SortFirstSubArray(firstArray);
            SortSecondSubArray(secondArray);
            //merge to main array
            MergeMethod(nArray, firstArray, secondArray);
            //print
            Console.WriteLine(string.Join("\n", nArray));
        }

        private static void MergeMethod(int[] nArray, int[] firstArray, int[] secondArray)
        {
            int firstIndex = 0;
            int secondIndex = 0;
            for (int mainIndex = 0; mainIndex < nArray.Length; mainIndex++)
            {
                if (firstArray[firstIndex] < secondArray[secondIndex])
                {
                    nArray[mainIndex] = firstArray[firstIndex];
                    if (firstIndex < firstArray.Length - 1)
                    {
                        firstIndex++;
                    }
                    else
                    {
                        firstArray[firstIndex] = int.MaxValue;
                    }
                }
                else //firstArray[firstIndex] > secondArray[secondIndex]
                {
                    nArray[mainIndex] = secondArray[secondIndex];
                    if (secondIndex < secondArray.Length - 1)
                    {
                        secondIndex++;
                    }
                    else
                    {
                        secondArray[secondIndex] = int.MaxValue;
                    }
                }
            }
        }

        private static void SortSecondSubArray(int[] secondArray)
        {
            int temp = 0;
            for (int firstIndex = 0; firstIndex < secondArray.Length; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < secondArray.Length; secondIndex++)
                {
                    if (secondArray[firstIndex] > secondArray[secondIndex])
                    {
                        temp = secondArray[firstIndex];
                        secondArray[firstIndex] = secondArray[secondIndex];
                        secondArray[secondIndex] = temp;
                    }
                }
            }
        }

        private static void SortFirstSubArray(int[] firstArray)
        {
            int temp = 0;
            for (int firstIndex = 0; firstIndex < firstArray.Length; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < firstArray.Length; secondIndex++)
                {
                    if (firstArray[firstIndex] > firstArray[secondIndex])
                    {
                        temp = firstArray[firstIndex];
                        firstArray[firstIndex] = firstArray[secondIndex];
                        firstArray[secondIndex] = temp;
                    }
                }
            }
        }

        private static void FragmentNArrayToSecondArray(int n, int[] nArray, int[] secondArray)
        {
            for (int i = n / 2; i < n; i++)
            {
                secondArray[i - (n / 2)] = nArray[i];
            }
        }

        private static void FragmentNArrayToFirstArray(int n, int[] nArray, int[] firstArray)
        {
            for (int i = 0; i < n / 2; i++)
            {
                firstArray[i] = nArray[i];
            }
        }

        private static void ParseToArray(int n, int[] nArray)
        {
            for (int i = 0; i < n; i++)
            {
                nArray[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
