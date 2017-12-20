using System;
using System.Linq;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle4
    {
        public static int Part1(string[] input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var words = line.Split();
                if (words.Length == words.Distinct().Count())
                    total++;
            }
            return total;
        }

        public static int Part2(string[] input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var words = line.Split().ToList();
                var sortedWords = words.Select(x => string.Concat(x.OrderBy(c => c))).ToList();

                if (sortedWords.Count == sortedWords.Distinct().Count())
                    total++;

            }
            return total;
        }
    }
}
