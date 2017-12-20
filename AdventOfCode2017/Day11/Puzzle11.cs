using System;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle11
    {
        private static int _xPos;
        private static int _yPos;
        private static int _zPos;

        public static int Part1(string input)
        {
            var steps = input.Split(',');

            foreach (var movement in steps)
                Move(movement);

            var distance = (Math.Abs(_xPos) + Math.Abs(_yPos) + Math.Abs(_zPos)) / 2;

            return distance;
        }

        public static int Part2(string input)
        {
            var steps = input.Split(',');
            _xPos = 0;
            _yPos = 0;
            _zPos = 0;
            var distance = 0;
            foreach (var movement in steps)
            {
                Move(movement);
                distance = Math.Max(distance,(Math.Abs(_xPos) + Math.Abs(_yPos) + Math.Abs(_zPos)) / 2);
            }


            return distance;
        }

        private static void Move(string movement)
        {
            switch (movement)
            {
                case "n":
                    _yPos++;
                    _zPos--;
                    break;
                case "ne":
                    _xPos++;
                    _zPos--;
                    break;
                case "nw":
                    _yPos++;
                    _xPos--;
                    break;
                case "s":
                    _yPos--;
                    _zPos++;
                    break;
                case "se":
                    _yPos--;
                    _xPos++;
                    break;
                case "sw":
                    _xPos--;
                    _zPos++;
                    break;
            }
        }

    }
}
