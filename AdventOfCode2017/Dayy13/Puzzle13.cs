using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle13
    {
        public static int Part1(string[] input)
        {
            var total = PassThrough(input, 0);
            return total;
        }

        public static int Part2(string[] input)
        {
            var caught = true;
            var delay = 0;
            while (caught)
            {
                if (PassThrough(input, delay) == 0)
                    caught = false;

                delay++;
            }

            return delay - 1;
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
