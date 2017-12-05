using System;
using System.Linq;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle2
    {
        public static void Part1()
        {
            var total = 0;
            using (var stream = new StreamReader("Inputs/Puzzle2.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var digits = Array.ConvertAll(line.Split(), int.Parse);
                    var range = digits.Max() - digits.Min();
                    total += range;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 2A answer is {total}");
        }

        public static void Part2()
        {
            var total = 0;
            using (var stream = new StreamReader("Inputs/Puzzle2.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
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
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 2B answer is {total}");
        }
    }
}
