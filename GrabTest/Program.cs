using System;
using System.Collections.Generic;

namespace GrabTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SoldierRankSolution(null);
            //Console.WriteLine(SoldierRankSolution(new[] { 4, 4, 3, 3, 1, 0 }));
            //Console.WriteLine(SoldierRankSolution(new[] { }));
            RepeatedSquareRoot(10, 16);
        }

        static int RepeatedSquareRoot(int A, int B)
        {
            if ((A > B) || A < 2 || B > 1000000000)
                return 0;

            int maxRepeated = 0;
            var startSquares = Math.Ceiling(Math.Sqrt(A));
            var endSquares = Math.Floor(Math.Sqrt(B));

            while (endSquares >= startSquares)
            {
                startSquares = Math.Ceiling(Math.Sqrt(startSquares));
                endSquares = Math.Floor(Math.Sqrt(endSquares));
                maxRepeated++;
            }

            return maxRepeated;
        }

        static int SoldierRankSolution(int[] ranks)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (ranks == null || ranks.Length < 2 || ranks.Length > 100000) return 0;
            int soldiersWithSuperior = 0;
            Dictionary<int, int> soldierCount = new Dictionary<int, int>();
            for (int i = 0; i < ranks.Length; i++)
            {
                int key = ranks[i];
                if (key < 0 || key > 1000000000) continue;
                if (soldierCount.ContainsKey(key))
                    soldierCount[key] += 1;
                else
                    soldierCount.Add(key, 1);
            }
            foreach (var key in soldierCount.Keys)
            {
                if (soldierCount.ContainsKey(key + 1))
                {
                    soldiersWithSuperior += soldierCount[key];
                }
            }
            return soldiersWithSuperior;
        }
    }
}
