using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle8
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("Inputs/Puzzle8.txt");
            var nameValueDictionary = input.Select(i => i.Split().First().Trim()).Distinct().ToDictionary(x => x, x => 0);
            foreach (var instruction in input)
            {
                var parts = instruction.Split();
                if (CheckCondition(nameValueDictionary[parts[4]], int.Parse(parts[6]), parts[5]))
                {
                    //do instruction
                    if (parts[1] == "inc")
                        nameValueDictionary[parts[0]] = nameValueDictionary[parts[0]] + int.Parse(parts[2]);
                    else
                        nameValueDictionary[parts[0]] = nameValueDictionary[parts[0]] - int.Parse(parts[2]);
                }
            }

            var maxValue = nameValueDictionary.Values.Max();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 8A answer is {maxValue}");
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("Inputs/Puzzle8.txt");

            var maxValue = 0;
            var nameValueDictionary = input.Select(i => i.Split().First().Trim()).Distinct().ToDictionary(x => x, x => 0);
            foreach (var instruction in input)
            {
                var parts = instruction.Split();
                if(CheckCondition(nameValueDictionary[parts[4]], int.Parse(parts[6]), parts[5]))
                {
                    //do instruction
                    if (parts[1] == "inc")
                        nameValueDictionary[parts[0]] = nameValueDictionary[parts[0]] + int.Parse(parts[2]);
                    else
                        nameValueDictionary[parts[0]] = nameValueDictionary[parts[0]] - int.Parse(parts[2]);
                }

                if (nameValueDictionary.Values.Max() > maxValue)
                    maxValue = nameValueDictionary.Values.Max();
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 8B answer is {maxValue}");
        }

        private static bool CheckCondition(int currentValue, int valueToCompare, string condition)
        {
            switch (condition)
            {
                case ">":
                    return currentValue > valueToCompare;
                case "<":
                    return currentValue < valueToCompare;
                case ">=":
                    return currentValue >= valueToCompare;
                case "<=":
                    return currentValue <= valueToCompare;
                case "==":
                    return currentValue == valueToCompare;
                case "!=":
                    return currentValue != valueToCompare;
                default:
                    throw new Exception("Unrecognized operation");
            }
        }

    }
}
