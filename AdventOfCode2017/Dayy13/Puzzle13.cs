using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle13
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("Inputs/Puzzle13.txt");
            var total = PassThrough(input, 0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 13A answer is {total}");
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("Inputs/Puzzle13.txt");
            var caught = true;
            var delay = 0;
            while (caught)
            {
                if (PassThrough(input, delay) == 0)
                    caught = false;

                delay++;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 13B answer is {delay - 1}");
        }

        private static int PassThrough(IEnumerable<string> input, int delay)
        {
            var total = 0;
            var layers = (from line in input
                select line.Split(':')
                into parts
                select new Layer
                {
                    LayerNumber = int.Parse(parts[0].Trim()),
                    Depth = int.Parse(parts[1].Trim())
                }).ToList();

            foreach (var layer in layers)
            {
                var positionOfScanner = (layer.LayerNumber + delay) % (2 * layer.Depth - 2);
                if (positionOfScanner == 0)
                    total += layer.Depth * (layer.LayerNumber + delay);
            }

            return total;
        }


    }

    public class Layer
    {
        public int LayerNumber { get; set; }
        public int Depth { get; set; }
    }
}
