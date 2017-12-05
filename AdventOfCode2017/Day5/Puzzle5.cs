using System;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle5
    {
        public static void Part1()
        {
            var total = 0;
            var numbers = Array.ConvertAll(File.ReadAllLines("Inputs/Puzzle5.txt"), int.Parse);
            var currentPosition = 0;
            while (currentPosition < numbers.Length)
            {
                var offset = numbers[currentPosition];
                numbers[currentPosition]++;
                currentPosition += offset;
                total++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 5A answer is {total}");
        }

        public static void Part2()
        {
            var total = 0;
            var numbers = Array.ConvertAll(File.ReadAllLines("Inputs/Puzzle5.txt"), int.Parse);
            var currentPosition = 0;
            while (currentPosition < numbers.Length)
            {
                var offset = numbers[currentPosition];
                if (offset >= 3)
                    numbers[currentPosition]--;
                else
                    numbers[currentPosition]++;
                currentPosition += offset;
                total++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 5B answer is {total}");
        }
    }
}
