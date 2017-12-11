using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle10
    {
        public static void Part1()
        {
            var input = Array.ConvertAll(File.ReadAllText("Inputs/Puzzle10.txt").Split(','),int.Parse);

            var elements = Enumerable.Range(0, 256).ToList();
            var total = 0;
            var currentPosition = 0;
            var skipSize = 0;

            foreach (var length in input)
            {
                var newList = new List<int>();
                var numbersToReverse = elements.Skip(currentPosition).Take(length).ToList();
                var numbersFromBeginning = 0;
                if (numbersToReverse.Count < length)
                {
                    numbersFromBeginning = length - numbersToReverse.Count;
                    numbersToReverse.AddRange(elements.Take(length - numbersToReverse.Count));
                }

                numbersToReverse.Reverse();

                if (numbersFromBeginning > 0)
                    newList.AddRange(numbersToReverse.Skip(numbersToReverse.Count - numbersFromBeginning).Take(numbersFromBeginning));

                for (int i = newList.Count; i < currentPosition; i++)
                    newList.Add(elements[i]);
                
                newList.AddRange(numbersToReverse.Take(numbersToReverse.Count - numbersFromBeginning));

                if (newList.Count < elements.Count)
                    newList.AddRange(elements.Skip(newList.Count));

                elements = newList;
                currentPosition = currentPosition + length + skipSize;

                if (currentPosition > elements.Count)
                    currentPosition = currentPosition - elements.Count;
                skipSize++;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 10A answer is {elements[0] * elements[1]}");
        }

        public static void Part2()
        {
            var input = Array.ConvertAll(File.ReadAllText("Inputs/Puzzle10.txt").ToCharArray(), x => (int)(byte)Convert.ToChar(x)).ToList();
            input.Add(17);
            input.Add(31);
            input.Add(73);
            input.Add(47);
            input.Add(23);
            var elements = Enumerable.Range(0, 256).ToList();
            var total = 0;
            var currentPosition = 0;
            var skipSize = 0;
            for (int j = 0; j < 64; j++)
            {
                foreach (var length in input)
                {
                    var newList = new List<int>();
                    var numbersToReverse = elements.Skip(currentPosition).Take(length).ToList();
                    var numbersFromBeginning = 0;
                    if (numbersToReverse.Count < length)
                    {
                        numbersFromBeginning = length - numbersToReverse.Count;
                        numbersToReverse.AddRange(elements.Take(length - numbersToReverse.Count));
                    }

                    numbersToReverse.Reverse();

                    if (numbersFromBeginning > 0)
                        newList.AddRange(numbersToReverse.Skip(numbersToReverse.Count - numbersFromBeginning)
                                             .Take(numbersFromBeginning));

                    for (int i = newList.Count; i < currentPosition; i++)
                        newList.Add(elements[i]);

                    newList.AddRange(numbersToReverse.Take(numbersToReverse.Count - numbersFromBeginning));

                    if (newList.Count < elements.Count)
                        newList.AddRange(elements.Skip(newList.Count));

                    elements = newList;
                    currentPosition = currentPosition + length + skipSize;

                    while (currentPosition > elements.Count)
                        currentPosition = currentPosition - elements.Count;

                    skipSize++;
                }
            }

            var denseHash = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                var value = 0;
                var toHash = elements.Skip(i * 16).Take(16);
                foreach (var num in toHash)
                {
                    value ^= num;
                }
                denseHash.Add(value.ToString("X"));
            }

            var hash = string.Join("", denseHash);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 10A answer is {hash.ToLower()}");
        }

    }
}
