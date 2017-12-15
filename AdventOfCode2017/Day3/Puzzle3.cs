using System;
using System.CodeDom;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle3
    {
        public static int Part1(int input)
        {
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

            return totalSteps;
        }

        public static string Part2(int input)
        {
            return "Puzzle 3B not implemented. I just did this in excel...";
        }
    }
}
