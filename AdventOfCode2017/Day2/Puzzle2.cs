using System;
using System.Linq;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle2
    {
        public static int Part1(string[] input)
        {
            var total = 0;
            foreach(var line in input)
            {
                var digits = Array.ConvertAll(line.Split(), int.Parse);
                var range = digits.Max() - digits.Min();
                total += range;
            }
            return total;
        }

        public static int Part2(string[] input)
        {
            var total = 0;
            foreach(var line in input)
            {
                var digits = Array.ConvertAll(line.Split(), int.Parse);
                for (var i = 0; i < digits.Length; i++)
                {
                    for (var j = 0; j < digits.Length; j++)
                    {
                        if (j == i)
                            continue;

                        if (digits[j] % digits[i] == 0 || digits[i] % digits[j] == 0)
                        {
                            total += (digits[j] / digits[i]);
                        }
                    }
                }
            }
            return total;
        }
    }
}
