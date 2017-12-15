using System;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle1
    {
        public static int Part1(string input)
        {
            var splitInput = input.Select(c => Convert.ToInt32(c.ToString())).ToArray();
            var total = splitInput.Where((t, i) => i == splitInput.Length - 1 && t == splitInput[0] || t == splitInput[i + 1]).Sum();
            Console.ForegroundColor = ConsoleColor.Cyan;
            return total;
        }

        public static int Part2(string input)
        {
            var firstHalf = input.Substring(0, input.Length / 2);
            var secondHalf = input.Substring(input.Length / 2);
            var total = firstHalf.Where((t, i) => t.ToString() == secondHalf[i].ToString()).Sum(t => int.Parse(t.ToString()) * 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            return total;
        }
    }
}
