using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle14
    {
        public static int Part1(string input)
        {
            var grid = GetGrid(input);
            var total = Regex.Matches(string.Join("", grid), "1").Count;
            return total;
        }

        public static int Part2(string input)
        {
            var grid = GetGrid(input);
            var visited = new bool[128, 128];
            var regions = 0;

            for (var y = 0; y < visited.GetLength(1); y++) // rows
            {
                for (var x = 0; x < visited.GetLength(0); x++) // columns
                {
                    if (visited[x, y] || grid[x][y] == '0')
                    {
                        continue;
                    }

                    Visit(x, y, grid, visited);
                    regions++;
                }
            }

            return regions;
        }

        private static List<string> GetGrid(string input)
        {
            var grid = new List<string>();
            for (var i = 0; i < 128; i++)
            {
                var row = $"{input}-{i}";
                var hash = Puzzle10.Part2(row);
                var binary = HexToBinary(hash);
                grid.Add(binary);
            }
            return grid;
        }

        private static readonly Dictionary<char, string> HexMap = new Dictionary<char, string> {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'a', "1010" },
            { 'b', "1011" },
            { 'c', "1100" },
            { 'd', "1101" },
            { 'e', "1110" },
            { 'f', "1111" }
        };

        private static string HexToBinary(string hex)
        {
            var result = new StringBuilder();
            foreach (var c in hex)
            {
                result.Append(HexMap[char.ToLower(c)]);
            }
            return result.ToString();
        }

        private static void Visit(int x, int y, IReadOnlyList<string> input, bool[,] visited)
        {
            if (visited[x, y])
            {
                return;
            }

            visited[x, y] = true;

            if (input[x][y] == '0')
            {
                return;
            }

            if (x > 0)
                Visit(x - 1, y, input, visited);
            if (x < 127)
                Visit(x + 1, y, input, visited);
            if (y > 0)
                Visit(x, y - 1, input, visited);
            if (y < 127)
                Visit(x, y + 1, input, visited);
        }


    }
}
