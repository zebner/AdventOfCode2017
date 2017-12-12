using System;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle11
    {
        private static int _xPos;
        private static int _yPos;
        private static int _zPos;

        public static void Part1()
        {
            var input = File.ReadAllText("Inputs/Puzzle11.txt").Split(',');

            foreach (var movement in input)
                Move(movement);

            var distance = (Math.Abs(_xPos) + Math.Abs(_yPos) + Math.Abs(_zPos)) / 2;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 11A answer is {distance}");
        }

        public static void Part2()
        {
            var input = File.ReadAllText("Inputs/Puzzle11.txt").Split(',');
            _xPos = 0;
            _yPos = 0;
            _zPos = 0;
            var distance = 0;
            foreach (var movement in input)
            {
                Move(movement);
                distance = Math.Max(distance,(Math.Abs(_xPos) + Math.Abs(_yPos) + Math.Abs(_zPos)) / 2);
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 11B answer is {distance}");
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
