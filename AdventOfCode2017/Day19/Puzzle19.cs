using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Puzzles
{


    public class Puzzle19
    {
        private static readonly StringBuilder OrderedLetters = new StringBuilder();
        public static string Part1(string[] input)
        {
            NavigateTubes(input);
            return OrderedLetters.ToString();
        }

        public static long Part2(string[] input)
        {
            return NavigateTubes(input);
        }

        private static int NavigateTubes(string[] input)
        {
            var totalSteps = 0;
            var row = 0;
            var column = input[row].IndexOf("|", StringComparison.Ordinal);
            var direction = 'S';
            var finished = false;
            while (!finished)
            {
                var entireColumn = new List<char>();
                var entireRow = new List<char>();
                switch (direction)
                {
                    case 'S':
                        entireColumn = input.Select(x => x[column]).Skip(row + 1).ToList();
                        break;
                    case 'N':
                        entireColumn = input.Select(x => x[column]).Take(row).ToList();
                        break;
                    case 'E':
                        entireRow = input[row].Skip(column + 1).ToList();
                        break;
                    case 'W':
                        entireRow = input[row].Take(column).ToList();
                        break;
                }

                OrderedLetters.Append(GetLetters(direction, entireRow.Any() ? entireRow : entireColumn));

                if (IsLast(direction, entireRow.Any() ? entireRow : entireColumn))
                    finished = true;

                var plusLocation = 0;
                if (direction == 'S')
                {
                    plusLocation = entireColumn.IndexOf('+');
                    totalSteps += plusLocation + 1;
                    row = plusLocation + row + 1;
                    var nextChar = input[row][column - 1].ToString();
                    if (string.IsNullOrWhiteSpace(nextChar) || nextChar == "|")
                        direction = FindNewDirection(direction, '+');
                    else
                        direction = FindNewDirection(direction, '-');

                }
                else if (direction == 'N')
                {
                    plusLocation = entireColumn.LastIndexOf('+');
                    totalSteps += entireColumn.Count - plusLocation;
                    row = plusLocation;
                    var nextChar = input[row][column - 1].ToString();
                    if (string.IsNullOrWhiteSpace(nextChar) || nextChar == "|")
                        direction = FindNewDirection(direction, '+');
                    else
                        direction = FindNewDirection(direction, '-');
                }
                else if (direction == 'E')
                {
                    plusLocation = entireRow.IndexOf('+');
                    totalSteps += plusLocation + 1;
                    column = plusLocation + column + 1;
                    var nextChar = input[row - 1][column].ToString();
                    if (string.IsNullOrWhiteSpace(nextChar) || nextChar == "-")
                        direction = FindNewDirection(direction, '-');
                    else
                        direction = FindNewDirection(direction, '+');
                }
                else if (direction == 'W')
                {
                    plusLocation = entireRow.LastIndexOf('+');
                    totalSteps += entireRow.Count - plusLocation;
                    column = plusLocation;
                    var nextChar = input[row - 1][column].ToString();
                    if (string.IsNullOrWhiteSpace(nextChar) || nextChar == "-")
                        direction = FindNewDirection(direction, '-');
                    else
                        direction = FindNewDirection(direction, '+');
                }

            }
            return totalSteps + 1;
        }

        #region Helpers
        private static char FindNewDirection(char currentDirection, char rotation)
        {
            switch (currentDirection)
            {
                case 'N':
                case 'S':
                    return rotation == '+' ? 'E' : 'W';
                default:
                    return rotation == '+' ? 'N' : 'S';
            }
        }

        private static bool IsLast(char direction, List<char> input)
        {
            if (direction == 'W' || direction == 'N')
            {
                var x = input.LastIndexOf('+');
                if (input.Skip(x).Contains(' '))
                    return true;
            }
            else
            {
                var y = input.IndexOf('+');
                if (input.Take(y).Contains(' '))
                    return true;
            }

            return false;
        }


        private static string GetLetters(char direction, List<char> input)
        {


            if (direction == 'W' || direction == 'N')
            {
                var x = input.LastIndexOf('+');
                var letters = string.Join("", input.Skip(x).Where(char.IsLetter));
                char[] charArray = letters.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            else
            {
                var y = input.IndexOf('+');
                return string.Join("", input.Take(y).Where(char.IsLetter));
            }
        }
        #endregion

    }
}
