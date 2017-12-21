///// Got a lot of help from reddit user u/2BitSalute on this one.


using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle21
    {
        static readonly List<string> _startingPattern = new List<string>()
        {
            ".#.",
            "..#",
            "###"
        };

        static Dictionary<string, string> _rules = new Dictionary<string, string>();

        public static int Part1(string[] input)
        {

            CreateRules(input);

            var pattern = _startingPattern;
            for (var i = 0; i < 5; i++)
            {
                var newPattern = ApplyRules(5);
                pattern = newPattern;
            }

            var poundsOnDots = string.Join("", pattern).GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
            var totalOn = poundsOnDots['#'];

            return totalOn;
        }

        public static long Part2(string[] input)
        {
            CreateRules(input);

            //now we have all possible permutations
            var pattern = _startingPattern;
            for (var i = 0; i < 18; i++)
            {
                var newPattern = ApplyRules(18);
                pattern = newPattern;
            }

            var poundsOnDots = string.Join("", pattern).GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
            var totalOn = poundsOnDots['#'];

            return totalOn;
        }


        private static void CreateRules(IEnumerable<string> input)
        {
            foreach (var rule in input)
            {
                var parts = rule.Split(new char[] { ' ', '=', '>', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var from = parts[0];
                var to = parts[1];

                //get all possible varitions of rule
                _rules.TryAdd(from, to);
                _rules.TryAdd(FlipRows(from), to);
                _rules.TryAdd(FlipColumns(from), to);

                //rotate and flip three more times
                for (var i = 0; i < 3; i++)
                {
                    var rotatedFrom = Rotate(from);
                    _rules.TryAdd(rotatedFrom, to);
                    _rules.TryAdd(FlipRows(rotatedFrom), to);
                    _rules.TryAdd(FlipColumns(rotatedFrom), to);

                    from = rotatedFrom;
                }
            }
        }

        private static List<string> ApplyRules(int iterations)
        {
            var pattern = _startingPattern;
            for (var i = 0; i < iterations; i++)
            {
                pattern = Grow(pattern, pattern.Count % 2 == 0 ? 2 : 3);
            }


            return pattern;
        }

        public static List<string> Grow(List<string> pattern, int size)
        {
            var newSize = size + 1;

            var newGrid = new string[pattern.Count / size * newSize];

            for (var j = 0; j * size < pattern.Count; j++)
            {
                for (var k = 0; k * size < pattern.Count; k++)
                {
                    var rule = GetRuleToMatch(pattern, j * size, k * size, size);
                    newGrid = GetNewSection(newGrid, _rules[rule], newSize, j * newSize, k * newSize);
                }
            }

            return newGrid.ToList();
        }

        public static string GetRuleToMatch(List<string> pattern, int startRow, int startColumn, int num)
        {
            var section = new string[num];
            for (var i = 0; i < num; i++)
            {
                for (var j = 0; j < num; j++)
                {
                    section[i] += pattern[i + startRow][j + startColumn];
                }
            }

            return string.Join("/", section);
        }

        public static string[] GetNewSection(string[] pattern, string rule, int size, int startRow, int startColumn)
        {
            var result = pattern;
            var rows = rule.Split('/');
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result[startRow + i] += rows[i][j];
                }
            }
            return result.ToArray();
        }

        #region RuleModifiers
        private static string FlipRows(string from)
        {
            var rows = from.Split('/');
            var newFrom = rows.Select(row => string.Join("", row.Reverse())).ToList();
            return string.Join("/", newFrom);
        }

        private static string FlipColumns(string from)
        {
            var rows = from.Split('/');
            var newRows = new string[rows.Length];

            for (var i = 0; i < rows.Length; i++)
            {
                newRows[rows.Length - i - 1] = rows[i];
            }

            return string.Join("/", newRows);
        }

        private static string Rotate(string from)
        {
            var rows = from.Split('/');
            var rotatedCharacters = new char[rows.Length, rows.Length];

            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows.Length; j++)
                {
                    rotatedCharacters[rows.Length - j - 1, i] = rows[i][j];
                }
            }

            var stringRows = new string[rows.Length];
            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows.Length; j++)
                {
                    stringRows[i] += rotatedCharacters[i, j];
                }
            }

            var result = string.Join("/", stringRows);
            return result;
        }
        #endregion
    }

    public static class ExtensionMethods21
    {
        public static void TryAdd(this Dictionary<string, string> dict, string key, string value)
        {
            if (dict.ContainsKey(key))
                return;

            dict.Add(key, value);
        }
    }
}
