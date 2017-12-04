using System;
using System.Linq;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle4
    {
        public static void Part1()
        {
            var total = 0;
            using (var stream = new StreamReader("Input/Puzzle4.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var words = line.Split();
                    if (words.Length == words.Distinct().Count())
                        total++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 4A answer is {total}");
        }

        public static void Part2()
        {
            var total = 0;
            using (var stream = new StreamReader("Input/Puzzle4.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var words = line.Split().ToList();
                    var sortedWords = words.Select(x => string.Concat(x.OrderBy(c => c))).ToList();

                    if (sortedWords.Count == sortedWords.Distinct().Count())
                        total++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 4B answer is {total}");
        }
    }
}
