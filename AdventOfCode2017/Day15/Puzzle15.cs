using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle15
    {
        public static int Part1(string[] input)
        {
            const long factorA = 16807;
            const long factorB = 48271;
            var valueA = long.Parse(input[0]);
            var valueB = long.Parse(input[1]);

            var totalMatches = 0;
            for (var i = 0; i < 40000000; i++)
            {
                valueA = valueA * factorA % 2147483647;
                valueB = valueB * factorB % 2147483647;
                var binaryA = Convert.ToString(valueA, 2);
                var binaryB = Convert.ToString(valueB, 2);

                if (binaryA.Substring(Math.Max(0,binaryA.Length - 16)) == binaryB.Substring(Math.Max(0,binaryB.Length - 16)))
                    totalMatches++;
            }

            return totalMatches;
        }

        public static int Part2(string[] input)
        {
            const long factorA = 16807;
            const long factorB = 48271;
            var valueA = long.Parse(input[0]);
            var valueB = long.Parse(input[1]);

            var totalMatches = 0;
            var aMatches = new List<long>();
            var bMatches = new List<long>();
            while(Math.Min(aMatches.Count,bMatches.Count) < 5000000)
            {
                valueA = valueA * factorA % 2147483647;
                valueB = valueB * factorB % 2147483647;

                if (valueA % 4 == 0)
                    aMatches.Add(valueA);
                
                if (valueB % 8 == 0)
                    bMatches.Add(valueB);
                
            }

            for (var i = 0; i < 5000000; i++)
            {
                var binaryA = Convert.ToString(aMatches[i], 2);
                var binaryB = Convert.ToString(bMatches[i], 2);
                if (binaryA.Substring(Math.Max(0, binaryA.Length - 16)) == binaryB.Substring(Math.Max(0, binaryB.Length - 16)))
                    totalMatches++;
            }

            return totalMatches;
        }


    }
}
