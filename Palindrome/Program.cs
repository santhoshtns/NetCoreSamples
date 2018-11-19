using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputstring = string.Empty;
            start:
            Console.WriteLine("Enter the input string to find the 3 longest palindrome present in the given string.");
            inputstring = Console.ReadLine();
            var result = PalindromFinder.GetPalindromesOrderBySizeDesc(inputstring, 3);
            if (result?.Count > 0)
                foreach (var palindrome in result)
                    Console.WriteLine(palindrome.ToString());
            else
                Console.WriteLine("No Palindromes found.");
            Console.WriteLine(Environment.NewLine);
            goto start;
        }
    }
}
