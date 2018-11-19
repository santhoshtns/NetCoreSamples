using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome
{
    public static class PalindromFinder
    {
        /// <summary>
        /// Gets the palindromes from the given input string odered in descending size.
        /// Selects only one palindrome in each size.
        /// Ignores other palindromes if more than one palindrome exist in each length
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="takeCount">The take count.</param>
        /// <param name="isCaseSensitive">if set to <c>true</c> [is case sensitive].</param>
        /// <returns></returns>
        public static List<PalindromeInfo> GetPalindromesOrderBySizeDesc(string input, int takeCount, bool isCaseSensitive = false)
        {
            var source = input.Trim();
            var length = source.Length;
            List<PalindromeInfo> palindromeInfos = new List<PalindromeInfo>();
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j <= length; j++)
                {
                    if (j - i > 1 && source[j - 1] == source[i])
                    {
                        string substring = source.Substring(i, j - i);
                        if (!string.IsNullOrWhiteSpace(substring) && IsPalindrome(substring))
                        {
                            // Check if palindrome is unique
                            if (palindromeInfos.Count(x => x.Text.Equals(substring,
                                 isCaseSensitive ? StringComparison.InvariantCulture :
                                 StringComparison.InvariantCultureIgnoreCase)) == 0)
                                palindromeInfos.Add(new PalindromeInfo(i, substring));
                        }
                    }
                }
            }
            var selected = palindromeInfos
                .GroupBy(k => k.Length)
                .Select(group => group.OrderBy(k => k.Text).First())
                .OrderByDescending(k => k.Length)
                .Take(takeCount).ToList();
            return selected;
        }

        /// <summary>
        /// Determines whether the specified sample to test is palindrome.
        /// </summary>
        /// <param name="sampleToTest">The sample to test.</param>
        /// <returns>
        ///   <c>true</c> if the specified sample to test is palidrome; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsPalindrome(string sampleToTest)
        {
            var obj = sampleToTest
                .Where((c, index) => c != sampleToTest[sampleToTest.Length - 1 - index]);
            return !obj.Any();
        }
    }
}
