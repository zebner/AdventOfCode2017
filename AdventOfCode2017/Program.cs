using System;
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
                try
                {
                    PlayPuzzle();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    Console.WriteLine("Press 1 to play another puzzle...");
                    playPuzzle = Console.ReadLine() == "1";
                }
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
                case "5":
                    Puzzle5.Part1();
                    Puzzle5.Part2();
                    break;
                case "6":
                    Puzzle6.Part1();
                    Puzzle6.Part2();
                    break;
                default:
                    throw new NotImplementedException("That puzzle is not available yet");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }  
    }
}

