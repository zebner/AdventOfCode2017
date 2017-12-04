using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using AdventOfCode2017.Puzzles;

namespace AdventOfCode2017
{
    internal class Program
    {
        private static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            var playPuzzle = true;
            while (playPuzzle)
            {
                PlayPuzzle();
                Console.WriteLine("Press 1 to play another puzzle...");
                playPuzzle = Console.ReadLine() == "1";
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private static void PlayPuzzle()
        {
            Console.WriteLine("Which puzzle do you want to play?");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Puzzle1.Part1();
                    Puzzle1.Part2();
                    break;
                case "2":
                    Puzzle2.Part1();
                    Puzzle2.Part2();
                    break;
                case "3":
                    Puzzle3.Part1();
                    Puzzle3.Part2();
                    break;
                case "4":
                    Puzzle4.Part1();
                    Puzzle4.Part2();
                    break;
                default:
                    Console.WriteLine("That puzzle is not available yet.");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }  
    }
}

