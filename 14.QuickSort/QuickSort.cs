using System;
using System.Collections.Generic;

namespace _14.QuickSort
{
    class QuickSort
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/14.%20Quick%20sort/README.md
          //1.input
            int n = int.Parse(Console.ReadLine());
            int[] nNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                nNumbers[i] = int.Parse(Console.ReadLine());
            }
            //2.initialize values
            int currentPivot = 0;
            List<int> currentPivotS = new List<int>();
            List<int> archivedPivots = new List<int>();
            List<int> lowElements = new List<int>();
            List<int> heightElements = new List<int>();
            int startIndex = 0;
            int endIndex = nNumbers.Length - 1;
            int offset = 0;
            bool isSort = true;
            bool continueSorting = true;
            //3.calc
            while (continueSorting)
            {
                //3a.choice pivot
                currentPivot = choicePivot(startIndex, endIndex, n, nNumbers);
                //3b.sorting
                Sorting(nNumbers, currentPivotS, currentPivot, lowElements, heightElements, startIndex, endIndex);
                //3c.parsing
                nNumbersNewValuesParsing(nNumbers, lowElements, heightElements, currentPivot, currentPivotS, archivedPivots, startIndex, endIndex);
                //3d.checking
                CheckingTheSequence(ref startIndex, ref endIndex, ref n, nNumbers, currentPivot, archivedPivots, ref offset, ref isSort, ref continueSorting);
                //3d-1.clear unneeded values
                lowElements.RemoveRange(0, lowElements.Count);
                heightElements.RemoveRange(0, heightElements.Count);
                currentPivotS.RemoveRange(0, currentPivotS.Count);
                ////3d-2.optimize (OPTIONAL STEP)
                //lowElements.TrimExcess();
                //heightElements.TrimExcess();
                //currentPivotS.TrimExcess();
                //archivedPivots.TrimExcess();
            }
            //4.print results
            Console.WriteLine(string.Join("\n", nNumbers));
        }
        //Methods
        //choice pivot methods  
        static int choicePivot(int startIndex, int endIndex, int n, int[] nNumbers)
        {
            int tempArrSum = nNumbersSum(nNumbers, startIndex, endIndex);
            int median = tempArrSum / n; //median - медианата(средния елемент в редицата)
            int biggerValue = 0; //most closer, BIGGER than "median" value
            int smallerValue = 0; //most closer smaller than "median" value
                                  //catch values
            for (int increase = startIndex; increase <= endIndex; increase++)
            {
                if (median <= nNumbers[increase])
                {
                    if (biggerValue > nNumbers[increase]) //За да се присвои нова стойност от "nNumbres", която да е максимално близка до медианата и в същото време по-ГОЛЯМА от нея, "biggerValue" трябва да е ПО-ГОЛЯМА от "nNumbers".  
                    {
                        biggerValue = nNumbers[increase];
                    }
                    if (biggerValue == 0) //This is ONLY for first parsing of value (from "nNumbers").
                    {
                        biggerValue = nNumbers[increase];
                    }
                }
            }
            for (int decrease = endIndex; decrease >= startIndex; decrease--)
            {
                if (median >= nNumbers[decrease])
                {
                    if (smallerValue < nNumbers[decrease]) //За да се присвои нова стойност от "nNumbres", която да е максимално близка до медианата и в същото време по-МАЛКА от нея, "smallerValue" трябва да е ПО-МАЛКА от "nNumbers".
                    {
                        smallerValue = nNumbers[decrease];
                    }
                    //here is no need statement for "first parsing"
                }
            }
            //choice value
            return ChoicePivotValue(median, biggerValue, smallerValue, nNumbers);
        }

        static int nNumbersSum(int[] nNumbers, int startIndex, int endIndex)
        {
            int tempArrSum = 0;
            for (int index = startIndex; index <= endIndex; index++)
            {
                tempArrSum = tempArrSum + nNumbers[index];
            }
            return tempArrSum;
        }

        static int ChoicePivotValue(int median, int biggerValue, int smallerValue, int[] nNumbers)
        {
            int thePivot = 0;
            int tempBiggerPivot = biggerValue - median;
            int tempSmallerPivot = median - smallerValue;
            if (tempBiggerPivot < tempSmallerPivot) //"tempBiggerPivot" is closer to "median"
            {
                thePivot = biggerValue;
            }
            else if (tempSmallerPivot < tempBiggerPivot) //"tempSmallerPivot" is closer to "median"
            {
                thePivot = smallerValue;
            }
            else if (tempBiggerPivot == tempSmallerPivot)
            {
                thePivot = biggerValue;
            }
            return thePivot;
        }

        //sorting method
        static void Sorting(int[] nNumbers, List<int> currentPivotS, int currentPivot, List<int> lowElements, List<int> heightElements, int startIndex, int endIndex)
        {
            for (int index = startIndex; index <= endIndex; index++)
            {
                if (nNumbers[index] < currentPivot) //low elements
                {
                    lowElements.Add(nNumbers[index]);
                }
                else if (nNumbers[index] > currentPivot) //height elements
                {
                    heightElements.Add(nNumbers[index]);
                }
                else if (nNumbers[index] == currentPivot) //pivot and equal to pivot elements
                {
                    currentPivotS.Add(nNumbers[index]);
                }
            }
        }

        //parsing values to "nNumbers"
        static void nNumbersNewValuesParsing(int[] nNumbers, List<int> lowElements, List<int> heightElements, int currentPivot, List<int> currentPivotS, List<int> archivedPivots, int startIndex, int endIndex)
        {
            int offset = 0;
            int secondIndex = 0;
            //parse "lowElements"
            for (int index = startIndex; index < (lowElements.Count + startIndex); index++, secondIndex++)
            {
                nNumbers[index] = lowElements[secondIndex];
                offset = (index - startIndex) + 1; //the statement (index - startIndex) is a "counter"
            }
            //parse "pivot" and archive it
            secondIndex = 0;
            archivedPivots.Add(currentPivot);
            for (int index = (startIndex + offset); index < (currentPivotS.Count + startIndex + offset); index++, secondIndex++)
            {
                nNumbers[index] = currentPivotS[secondIndex];
            }
            //parse "heightElements"
            secondIndex = 0;
            for (int index = (startIndex + offset + currentPivotS.Count); index <= endIndex; index++, secondIndex++)
            {
                nNumbers[index] = heightElements[secondIndex];
            }
        }

        //checking the sequence
        static void CheckingTheSequence(ref int startIndex, ref int endIndex, ref int n, int[] nNumbers, int currentPivot, List<int> archivedPivots, ref int offset, ref bool isSort, ref bool continueSorting)
        {
            //int offset = 0;
            isSort = true;                  //this step is for reset "isSort"
            endIndex = nNumbers.Length - 1; //this step is for reset "endIndex"
            for (int nNumbsIndex = startIndex; nNumbsIndex < nNumbers.Length; nNumbsIndex++)
            {
                //check for sorted subsequences
                if (nNumbsIndex < nNumbers.Length - 1)
                {
                    if ((!(nNumbers[nNumbsIndex] <= nNumbers[nNumbsIndex + 1])) && (isSort == true)) //If the subsequence is NOT sorted. 
                    {                                                                                  //"!(nNumbers[nNumbsIndex] <= nNumbers[nNumbsIndex + 1])" --> check the current and second element of the subsequence
                        isSort = false;                                                                //"isSort == true" --> if "isSort" is == false, there is NO need for more checking, the subsequence is NOT sorted! 
                    }
                }
                //get new subsequences for sorting
                if (nNumbers[nNumbsIndex] == currentPivot)
                {
                    if (isSort == true) //parse "startIndex, currentPibvot, offset"
                    {
                        ChangePivotAndIndexes(nNumbers, ref n, ref offset, ref currentPivot, archivedPivots, ref startIndex, ref endIndex, nNumbsIndex);
                    }
                    else //"isSort" == false
                    {
                        endIndex = nNumbsIndex - 1;
                        n = nNumbsIndex - offset;    //change the "n" elements, entered at the beginning by user, based on the NEW subsequence.
                        break;
                    }
                }
                if ((nNumbsIndex == nNumbers.Length - 1) && (isSort == false))     
                {                                                                  
                    n = nNumbsIndex - offset;        //this is analogical condition to the last but one statement (where: "isSort" == false). Here only, is need to change "n" elements ("endIndex" remain reset, by default).
                }
                else if ((nNumbsIndex == nNumbers.Length - 1) && (isSort == true)) //if true, there is NO need to continue, all elements IS SORTED (startIndex is == to endIndex) !
                {
                    continueSorting = false;
                }
            }
        }

        static void ChangePivotAndIndexes(int[] nNumbers, ref int n, ref int offset, ref int currentPivot, List<int> archivedPivots, ref int startIndex, ref int endIndex, int nNumbsIndex)
        {
            startIndex = nNumbsIndex + 1;        //here "+1" is need, to be skipped the "pivot" element
            offset = nNumbsIndex;                //"offset" is needed for eventual change of "n" elements
            archivedPivots.Remove(currentPivot);
            if ((archivedPivots.Count - 1) >= 0) //check, if the "archivedPivots" has a value, parse it
            {
                currentPivot = archivedPivots[archivedPivots.Count - 1];
            }
        }

    }
}
