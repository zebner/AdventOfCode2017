using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle6
    {
        public static void Part1()
        {
            var banks = Array.ConvertAll(File.ReadAllText("Inputs/Puzzle6.txt").Split(), int.Parse);
            var usedConfigurations = new List<int[]>();
            Redistribute(usedConfigurations, banks);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 6A answer is {usedConfigurations.Count}");
        }

        public static void Part2()
        {
            var banks = Array.ConvertAll(File.ReadAllText("Inputs/Puzzle6.txt").Split(), int.Parse);
            var usedConfigurations = new List<int[]>();
            Redistribute(usedConfigurations, banks);

            var numInInfiniteLoop = usedConfigurations.Count - usedConfigurations.IndexOf(usedConfigurations.First(c => c.SequenceEqual(banks)));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 6A answer is {numInInfiniteLoop}");
        }

        private static void Redistribute(ICollection<int[]> usedConfigurations, IList<int> banks)
        {
            while (!usedConfigurations.Any(c => c.SequenceEqual(banks)))
            {
                usedConfigurations.Add(banks.ToArray());

                var maxBlock = banks.ToList().IndexOf(banks.Max());
                var blocksToDistribute = banks[maxBlock];
                banks[maxBlock] = 0;
                while (blocksToDistribute > 0)
                {
                    maxBlock++;
                    if (maxBlock >= banks.Count)
                        maxBlock = 0;

                    banks[maxBlock]++;
                    blocksToDistribute--;
                }
            }
        }
    }
}
