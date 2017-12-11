using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle11
    {
        public static void Part1()
        {
            var input = File.ReadAllText("Inputs/Puzzle11.txt").Split(',');

            var xPos = 0;
            var yPos = 0;
            var zPos = 0;

            foreach (var movement in input)
            {
                switch (movement)
                {
                    case "n":
                        yPos++;
                        zPos--;
                        break;
                    case "ne":
                        xPos++;
                        zPos--;
                        break;
                    case "nw":
                        yPos++;
                        xPos--;
                        break;
                    case "s":
                        yPos--;
                        zPos++;
                        break;
                    case "se":
                        yPos--;
                        xPos++;
                        break;
                    case "sw":
                        xPos--;
                        zPos++;
                        break;
                }
            }

            var distance = (Math.Abs(xPos) + Math.Abs(yPos) + Math.Abs(zPos)) / 2;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 11A answer is {distance}");
        }

        public static void Part2()
        {
            var input = File.ReadAllText("Inputs/Puzzle11.txt").Split(',');

            var xPos = 0;
            var yPos = 0;
            var zPos = 0;

            var distance = 0;
            foreach (var movement in input)
            {
                switch (movement)
                {
                    case "n":
                        yPos++;
                        zPos--;
                        break;
                    case "ne":
                        xPos++;
                        zPos--;
                        break;
                    case "nw":
                        yPos++;
                        xPos--;
                        break;
                    case "s":
                        yPos--;
                        zPos++;
                        break;
                    case "se":
                        yPos--;
                        xPos++;
                        break;
                    case "sw":
                        xPos--;
                        zPos++;
                        break;
                }

                distance = Math.Max(distance,(Math.Abs(xPos) + Math.Abs(yPos) + Math.Abs(zPos)) / 2);
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 11A answer is {distance}");
        }

    }
}
