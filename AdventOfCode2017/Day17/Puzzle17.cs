using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle17
    {
        public static int Part1(string input)
        {
            var steps = int.Parse(input);
            var buffer = new List<int>{ 0 };
            var currentPostion = 0;
            for (var i = 1; i < 2018; i++)
            {
                currentPostion = (currentPostion + steps) % buffer.Count() + 1;
                buffer.Insert(currentPostion, i);

            }
            return buffer[currentPostion + 1];

        }

        public static int Part2(string input)
        {
            var steps = int.Parse(input);
            var currentPostion = 0;
            var numAfterZero = 0;
            for (var i = 1; i < 50000001; i++)
            {
                currentPostion = (currentPostion + steps) % i + 1;
                if (currentPostion == 1)
                    numAfterZero = i;

            }
            return numAfterZero;
        }

     


    }
}
