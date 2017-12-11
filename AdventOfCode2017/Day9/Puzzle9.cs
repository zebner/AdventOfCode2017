using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle9
    {
        public static void Part1()
        {
            var input = File.ReadAllText("Inputs/Puzzle9.txt");
            var total = 0;
            var groupNumber = 0;
            var inGarbage = false;
            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i].ToString();
                if (inGarbage)
                {
                    switch (character)
                    {
                        case "!":
                            i++; //extra skip
                            break;
                        case ">":
                            inGarbage = false;
                            break;
                    }
                }
                else
                {
                    switch (character)
                    {
                        case "<":
                            inGarbage = true;
                            break;
                        case "{":
                            groupNumber++;
                            break;
                        case "}":
                            total += groupNumber;
                            groupNumber--;
                            break;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 9A answer is {total}");
        }

        public static void Part2()
        {
            var input = File.ReadAllText("Inputs/Puzzle9.txt");
            var total = 0;
            var inGarbage = false;
            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i].ToString();
                if (inGarbage)
                {
                    switch (character)
                    {
                        case "!":
                            i++; //extra skip
                            break;
                        case ">":
                            inGarbage = false;
                            break;
                        default:
                            total++;
                            break;
                    }
                }
                else if (character == "<")
                        inGarbage = true;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 9B answer is {total}");
        }

    }
}
