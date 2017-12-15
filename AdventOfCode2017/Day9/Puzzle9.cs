using System;
using System.IO;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle9
    {
        public static int Part1(string input)
        {
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

            return total;
        }

        public static int Part2(string input)
        {
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

            return total;
        }

    }
}
