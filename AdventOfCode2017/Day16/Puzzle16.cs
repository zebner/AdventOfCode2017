using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle16
    {
        public static string Part1(string input)
        {
            var moves = input.Split(',');
            var dancers = new List<string>();
            dancers.Add("a");
            dancers.Add("b");
            dancers.Add("c");
            dancers.Add("d");
            dancers.Add("e");
            dancers.Add("f");
            dancers.Add("g");
            dancers.Add("h");
            dancers.Add("i");
            dancers.Add("j");
            dancers.Add("k");
            dancers.Add("l");
            dancers.Add("m");
            dancers.Add("n");
            dancers.Add("o");
            dancers.Add("p");
            return PerformDance(dancers, moves);


        }

        public static string Part2(string input)
        {
            var moves = input.Split(',');
            var dancers = new List<string>();
            dancers.Add("a");
            dancers.Add("b");
            dancers.Add("c");
            dancers.Add("d");
            dancers.Add("e");
            dancers.Add("f");
            dancers.Add("g");
            dancers.Add("h");
            dancers.Add("i");
            dancers.Add("j");
            dancers.Add("k");
            dancers.Add("l");
            dancers.Add("m");
            dancers.Add("n");
            dancers.Add("o");
            dancers.Add("p");
            var position = "";
            for (var i = 0; i < 1000000000 % 24; i++)
            {
                position = PerformDance(dancers, moves);
            }

            return position;
        }

        private static string PerformDance(List<string> dancers, string[] moves)
        {

            foreach (var move in moves)
            {
                switch (move[0])
                {
                    case 's':
                        var numDancers = int.Parse(move.Substring(1));
                        var dancersToMove = dancers.Skip(dancers.Count - numDancers).ToList();
                        dancers.InsertRange(0, dancersToMove);
                        dancers.RemoveRange(dancers.Count - numDancers, numDancers);
                        break;
                    case 'x':
                        var firstSwap = int.Parse(move.Substring(1, move.IndexOf("/") - 1));
                        var secondSwap = int.Parse(move.Substring(move.IndexOf("/") + 1));
                        var value1 = dancers[firstSwap];
                        var value2 = dancers[secondSwap];
                        dancers[firstSwap] = value2;
                        dancers[secondSwap] = value1;
                        break;
                    case 'p':
                        var firstPartner = move.Substring(1, move.IndexOf("/") - 1);
                        var secondPartner = move.Substring(move.IndexOf("/") + 1);
                        var dancer1 = dancers.FindIndex(d => d == firstPartner);
                        var dancer2 = dancers.FindIndex(d => d == secondPartner);
                        dancers[dancer1] = secondPartner;
                        dancers[dancer2] = firstPartner;
                        break;
                    default:
                        throw new Exception("I don't know that move");
                }
            }
            return string.Join("", dancers);
        }


    }
}
