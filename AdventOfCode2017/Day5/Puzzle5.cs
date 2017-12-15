using System;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle5
    {
        public static int Part1(string[] input)
        {
            var total = 0;
            var numbers = Array.ConvertAll(input, int.Parse);
            var currentPosition = 0;
            while (currentPosition < numbers.Length)
            {
                var offset = numbers[currentPosition];
                numbers[currentPosition]++;
                currentPosition += offset;
                total++;
            }
            return total;
        }

        public static int Part2(string[] input)
        {
            var total = 0;
            var numbers = Array.ConvertAll(input, int.Parse);
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
            return total;
        }
    }
}
