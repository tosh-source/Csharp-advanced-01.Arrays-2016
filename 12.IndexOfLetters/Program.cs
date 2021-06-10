using System;
using System.Linq;

namespace _12.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        { //condition: https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/01.%20Arrays/homework/12.%20Index%20of%20letters/README.md
            //input
            char[] charArr = Console.ReadLine().ToString().ToArray();
            //calc
            int charAsInt = 0;
            for (int i = 0; i < charArr.Length; i++)
            {
                charAsInt = charArr[i] - 97;
                Console.WriteLine(charAsInt);
            }
        }
    }
}
