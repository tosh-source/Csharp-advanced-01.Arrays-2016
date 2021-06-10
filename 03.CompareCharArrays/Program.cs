using System;

namespace _03.CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/03.%20Compare%20char%20arrays/README.md

            string first = Console.ReadLine();
            string second = Console.ReadLine();

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++) //check the smaller of both length
            {
                if (first[i] < second[i]) //first array is lexicographically smaller
                {
                    Console.WriteLine("<");
                    return;
                }
                else if (first[i] > second[i]) //second array is lexicographically smaller
                {
                    Console.WriteLine(">");
                    return;
                }
            }

            if (first.Length > second.Length)
            {
                Console.WriteLine(">");
            }
            else if(first.Length < second.Length)
            {
                Console.WriteLine("<");
            }
            else //first.Length = second.Length
            {
                Console.WriteLine("=");
            }
        }
    }
}

