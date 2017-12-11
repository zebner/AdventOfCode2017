using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle10
    {
        private static int _currentPosition;
        private static int _skipSize;
        public static void Part1()
        {
            var input = Array.ConvertAll(File.ReadAllText("Inputs/Puzzle10.txt").Split(','),int.Parse);

            var elements = Enumerable.Range(0, 256).ToList();
            elements = KnotHash(input, elements);

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

            _currentPosition = 0;
            _skipSize = 0;

            var elements = Enumerable.Range(0, 256).ToList();
            for (var j = 0; j < 64; j++)
            {
                elements = KnotHash(input, elements);
            }

            var denseHash = new StringBuilder();
            for (var i = 0; i < 16; i++)
            {
                var value = elements.Skip(i * 16).Take(16).Aggregate(0, (current, num) => current ^ num);
                denseHash.Append(value.ToString("X"));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 10B answer is {denseHash.ToString().ToLower()}");
        }

        private static List<int> KnotHash(IEnumerable<int> input, List<int> elements)
        {

            foreach (var length in input)
            {
                var newList = new List<int>();
                var numbersToReverse = elements.Skip(_currentPosition).Take(length).ToList();
                var numbersFromBeginning = 0;
                if (numbersToReverse.Count < length)
                {
                    numbersFromBeginning = length - numbersToReverse.Count;
                    numbersToReverse.AddRange(elements.Take(length - numbersToReverse.Count));
                }

                numbersToReverse.Reverse();

                if (numbersFromBeginning > 0)
                    newList.AddRange(numbersToReverse.Skip(numbersToReverse.Count - numbersFromBeginning).Take(numbersFromBeginning));

                for (var i = newList.Count; i < _currentPosition; i++)
                    newList.Add(elements[i]);

                newList.AddRange(numbersToReverse.Take(numbersToReverse.Count - numbersFromBeginning));

                if (newList.Count < elements.Count)
                    newList.AddRange(elements.Skip(newList.Count));

                elements = newList;
                _currentPosition = _currentPosition + length + _skipSize;

                while (_currentPosition > elements.Count)
                    _currentPosition = _currentPosition - elements.Count;

                _skipSize++;
            }

            return elements;
        }

    }
}
