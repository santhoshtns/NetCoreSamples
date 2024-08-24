using System.Globalization;

namespace DistinctCharCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.Name)).ToList();

            var result = GetIsoThreeCharacterCountryCode(regions, "CM", "Cameroon");

            Console.WriteLine("Hello, World!");

            var program = new Program();
            program.solution("abc", "bcd");
            program.solution("bacad", "abada");
            program.solution("axxz", "yzwy");
            program.solution("amz", "amz");
        }

        private static string GetIsoThreeCharacterCountryCode(List<RegionInfo> regions, string countryCde, string countryT)
        {
            string countryCode = countryCde?.Trim();
            string countryName = countryT.Trim();

            if (string.IsNullOrEmpty(countryName) && string.IsNullOrEmpty(countryCode))
            {
                return null;
            }

            RegionInfo regionInfo;
            //if (!string.IsNullOrEmpty(countryCode))
            //{
            //    regionInfo = new RegionInfo(countryCode);

            //}
            //else
            {
                regionInfo = regions.FirstOrDefault(r => r.EnglishName.Equals(countryName, StringComparison.InvariantCultureIgnoreCase));
            }

            return regionInfo?.ThreeLetterISORegionName;
        }

        public Dictionary<char, int> FindMostRepeatedCharacters(string input)
        {
            return input.GroupBy(c => c)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public int solution(string P, string Q)
        {
            var newS = new char[P.Length];
            var pOccurances = FindMostRepeatedCharacters(P);
            var qOccurances = FindMostRepeatedCharacters(Q);
            for (int i = 0; i < P.Length; i++)
            {
                if (P[i] == Q[i])
                {
                    newS[i] = Q[i];
                    continue;
                }
                if (pOccurances[P[i]] > qOccurances[Q[i]] || newS.Contains(P[i]))
                {
                    newS[i] = P[i];
                }
                else if (pOccurances[P[i]] < qOccurances[Q[i]] || newS.Contains(Q[i]))
                {
                    newS[i] = Q[i];
                }
                else if (pOccurances[P[i]] == qOccurances[Q[i]] && P.Contains(Q[i]))
                {
                    newS[i] = Q[i];
                }
                else if (pOccurances[P[i]] == qOccurances[Q[i]] && Q.Contains(P[i]))
                {
                    newS[i] = P[i];
                }
                else
                {
                    newS[i] = Q[i];
                }

                if (i > 18 && newS.Distinct().Count() > 20)
                {
                    break;
                }
            }

            return newS.Distinct().Count();
        }

        public int solution2(string P, string Q)
        {
            // Implement your solution here
            var minDistinctCharacters = P.Length > Q.Length ? P.Length : Q.Length;

            minDistinctCharacters = LoopReplaceCheck(Q, P, minDistinctCharacters);
            minDistinctCharacters = LoopReplaceCheck(P, Q, minDistinctCharacters);

            return minDistinctCharacters;
        }

        public int LoopReplaceCheck(string s1, string s2, int minDistinctCharacters)
        {
            var s1Distinct = s1.Distinct().ToArray();
            for (int i = 0; i < s1Distinct.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    var temp = s2.ToArray();
                    temp[j] = s1Distinct[i];
                    var count = CountDistinctLetters(new string(temp));
                    if (count < minDistinctCharacters)
                        minDistinctCharacters = count;
                }
            }
            return minDistinctCharacters;
        }

        public int CountDistinctLetters(string input)
        {
            // Use LINQ to count distinct characters in the string
            return input.Distinct().Count();
        }
    }
}
