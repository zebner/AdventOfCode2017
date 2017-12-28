using System;
using System.IO;
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
            Console.ForegroundColor = ConsoleColor.Cyan;;
            switch (input)
            {
                case "1":
                    var input1 = File.ReadAllText("Inputs/Puzzle01.txt");
                    Console.WriteLine($"Puzzle 1A answer is {Puzzle1.Part1(input1)}");
                    Console.WriteLine($"Puzzle 1B answer is {Puzzle1.Part2(input1)}");
                    break;
                case "2":
                    var input2 = File.ReadAllLines("Inputs/Puzzle02.txt");
                    Console.WriteLine($"Puzzle 2A answer is {Puzzle2.Part1(input2)}");
                    Console.WriteLine($"Puzzle 2B answer is {Puzzle2.Part2(input2)}");
                    break;
                case "3":
                    var input3 = 325489;
                    Console.WriteLine($"Puzzle 3A answer is {Puzzle3.Part1(input3)}");
                    Console.WriteLine($"Puzzle 3B answer is {Puzzle3.Part2(input3)}");
                    break;
                case "4":
                    var input4 = File.ReadAllLines("Inputs/Puzzle04.txt");
                    Console.WriteLine($"Puzzle 4A answer is {Puzzle4.Part1(input4)}");
                    Console.WriteLine($"Puzzle 4B answer is {Puzzle4.Part2(input4)}");
                    break;
                case "5":
                    var input5 = File.ReadAllLines("Inputs/Puzzle05.txt");
                    Console.WriteLine($"Puzzle 4A answer is {Puzzle5.Part1(input5)}");
                    Console.WriteLine($"Puzzle 4B answer is {Puzzle5.Part2(input5)}");
                    break;
                case "6":
                    var input6 = File.ReadAllText("Inputs/Puzzle06.txt");
                    Console.WriteLine($"Puzzle 6A answer is {Puzzle6.Part1(input6)}");
                    Console.WriteLine($"Puzzle 6B answer is {Puzzle6.Part2(input6)}");
                    break;
                case "7":
                    var input7 = File.ReadAllLines("Inputs/Puzzle07.txt");
                    Console.WriteLine($"Puzzle 7A answer is {Puzzle7.Part1(input7)}");
                    Console.WriteLine($"Puzzle 7B answer is {Puzzle7.Part2(input7)}");
                    break;
                case "8":
                    var input8 = File.ReadAllLines("Inputs/Puzzle08.txt");
                    Console.WriteLine($"Puzzle 8A answer is {Puzzle8.Part1(input8)}");
                    Console.WriteLine($"Puzzle 8B answer is {Puzzle8.Part2(input8)}");
                    break;
                case "9":
                    var input9 = File.ReadAllText("Inputs/Puzzle09.txt");
                    Console.WriteLine($"Puzzle 9A answer is {Puzzle9.Part1(input9)}");
                    Console.WriteLine($"Puzzle 9B answer is {Puzzle9.Part2(input9)}");
                    break;
                case "10":
                    var input10 = File.ReadAllText("Inputs/Puzzle10.txt");
                    Console.WriteLine($"Puzzle 10A answer is {Puzzle10.Part1(input10)}");
                    Console.WriteLine($"Puzzle 10B answer is {Puzzle10.Part2(input10)}");
                    break;
                case "11":
                    var input11 = File.ReadAllText("Inputs/Puzzle11.txt");
                    Console.WriteLine($"Puzzle 11A answer is {Puzzle11.Part1(input11)}");
                    Console.WriteLine($"Puzzle 11B answer is {Puzzle11.Part2(input11)}");
                    break;
                case "12":
                    var input12 = File.ReadAllLines("Inputs/Puzzle12.txt");
                    Console.WriteLine($"Puzzle 12A answer is {Puzzle12.Part1(input12)}");
                    Console.WriteLine($"Puzzle 12B answer is {Puzzle12.Part2(input12)}");
                    break;
                case "13":
                    var input13 = File.ReadAllLines("Inputs/Puzzle13.txt");
                    Console.WriteLine($"Puzzle 13A answer is {Puzzle13.Part1(input13)}");
                    Console.WriteLine($"Puzzle 13B answer is {Puzzle13.Part2(input13)}");
                    break;
                case "14":
                    var input14 = File.ReadAllText("Inputs/Puzzle14.txt");
                    Console.WriteLine($"Puzzle 14A answer is {Puzzle14.Part1(input14)}");
                    Console.WriteLine($"Puzzle 14B answer is {Puzzle14.Part2(input14)}");
                    break;
                case "15":
                    var input15 = File.ReadAllLines("Inputs/Puzzle15.txt");
                    Console.WriteLine($"Puzzle 15A answer is {Puzzle15.Part1(input15)}");
                    Console.WriteLine($"Puzzle 15B answer is {Puzzle15.Part2(input15)}");
                    break;
                case "16":
                    var input16 = File.ReadAllText("Inputs/Puzzle16.txt");
                    Console.WriteLine($"Puzzle 16A answer is {Puzzle16.Part1(input16)}");
                    Console.WriteLine($"Puzzle 16B answer is {Puzzle16.Part2(input16)}");
                    break;
                case "17":
                    var input17 = File.ReadAllText("Inputs/Puzzle17.txt");
                    Console.WriteLine($"Puzzle 17A answer is {Puzzle17.Part1(input17)}");
                    Console.WriteLine($"Puzzle 17B answer is {Puzzle17.Part2(input17)}");
                    break;
                case "18":
                    var input18 = File.ReadAllLines("Inputs/Puzzle18.txt");
                    Console.WriteLine($"Puzzle 18A answer is {Puzzle18.Part1(input18)}");
                    Console.WriteLine($"Puzzle 18B answer is {Puzzle18.Part2(input18)}");
                    break;
                case "19":
                    var input19 = File.ReadAllLines("Inputs/Puzzle19.txt");
                    Console.WriteLine($"Puzzle 19A answer is {Puzzle19.Part1(input19)}");
                    Console.WriteLine($"Puzzle 19B answer is {Puzzle19.Part2(input19)}");
                    break;
                case "20":
                    var input20 = File.ReadAllLines("Inputs/Puzzle20.txt");
                    Console.WriteLine($"Puzzle 20A answer is {Puzzle20.Part1(input20)}");
                    Console.WriteLine($"Puzzle 20B answer is {Puzzle20.Part2(input20)}");
                    break;
                case "21":
                    var input21 = File.ReadAllLines("Inputs/Puzzle21.txt");
                    Console.WriteLine($"Puzzle 21A answer is {Puzzle21.Part1(input21)}");
                    Console.WriteLine($"Puzzle 21B answer is {Puzzle21.Part2(input21)}");
                    break;
                case "22":
                    var input22 = File.ReadAllLines("Inputs/Puzzle22.txt");
                    Console.WriteLine($"Puzzle 22A answer is {Puzzle22.Part1(input22)}");
                    Console.WriteLine($"Puzzle 22B answer is {Puzzle22.Part2(input22)}");
                    break;
                case "23":
                    var input23 = File.ReadAllLines("Inputs/Puzzle23.txt");
                    Console.WriteLine($"Puzzle 23A answer is {Puzzle23.Part1(input23)}");
                    Console.WriteLine($"Puzzle 23B answer is {Puzzle23.Part2(input23)}");
                    break;
                default:
                    throw new NotImplementedException("That puzzle is not available yet");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }  
    }
}

