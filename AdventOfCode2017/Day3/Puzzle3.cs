using System;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle3
    {
        public static void Part1()
        {
            const int input = 325489;
            int totalSteps;
            var sqrt = (int)Math.Sqrt(input);
            if (sqrt % 2 == 0) //rings only start on odd numbers. find the lower one.
            {
                sqrt -= 1;
            }

            var overflow = input - (sqrt * sqrt); //number of steps into the new "ring"
            if (overflow == 0) //we are at the end of a "ring"
            {
                totalSteps = sqrt - 1;
            }
            else
            {
                var rowLength = sqrt + 2;
                var positionOnContainingRow = overflow % (rowLength - 1); // position in row that contains the input

                var distanceFromCenterOfRow = Math.Abs((rowLength - 1) / 2 - positionOnContainingRow); //steps from the center of the row
                var ring = (rowLength / 2) + 1; //1 ring = 1 loop around spiral. Each loop is 1 step farther from center
                totalSteps = distanceFromCenterOfRow + ring - 1;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 3 answer is {totalSteps}");
        }

        public static void Part2()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Puzzle 3B not implemented. I just did this in excel...");
        }
    }
}
