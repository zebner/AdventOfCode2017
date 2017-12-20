using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle8
    {
        public static int Part1(string[] input)
        {
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
            return maxValue;
        }

        public static int Part2(string[] input)
        {
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


            return maxValue;
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
