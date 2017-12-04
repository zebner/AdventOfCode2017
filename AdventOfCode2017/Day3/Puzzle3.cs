using System;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle3
    {
        public static void Part1()
        {
            const int input = 325489;
            var rowLength = 0;
            var sqrt = Math.Sqrt(input);
            rowLength = Convert.ToInt32(Math.Floor(sqrt));
            if (rowLength % 2 != 0)
                rowLength += 2;
            else
                rowLength += 1;

            if (sqrt % 1 == 0 && sqrt % 2 == 1) //its on the corner that starts the ring
                rowLength -= 2;

            var ring = (rowLength / 2) + 1;

            var distanceFromCenterOfRow = 0;
            var row1 = Enumerable.Range((rowLength * rowLength) - (rowLength - 1), rowLength).ToArray();
            var row2 = Enumerable.Range(row1[0] - rowLength + 1, rowLength).ToArray();
            var row3 = Enumerable.Range(row2[0] - rowLength + 1, rowLength).ToArray();
            var row4 = Enumerable.Range(row3[0] - rowLength + 2, rowLength - 1).ToArray();

            if (row1.Contains(input))
                distanceFromCenterOfRow = Math.Abs(((rowLength - 1) / 2) - (row1.Max() - input));
            if (row2.Contains(input))
                distanceFromCenterOfRow = Math.Abs(((rowLength - 1) / 2) - (row2.Max() - input));
            if (row3.Contains(input))
                distanceFromCenterOfRow = Math.Abs(((rowLength - 1) / 2) - (row3.Max() - input));
            if (row4.Contains(input))
                distanceFromCenterOfRow = Math.Abs(((rowLength - 1) / 2) - (row4.Max() - input));

            var totalSteps = (distanceFromCenterOfRow + ring) - 1;

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
