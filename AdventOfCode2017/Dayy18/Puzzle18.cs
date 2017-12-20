using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle18
    {
        public static long Part1(string[] input)
        {
            var soloSinger = new Duet(0, input);
            soloSinger.Run();
            return soloSinger.SndQueue.Last();
        }

        public static long Part2(string[] input)
        {

            var program0 = new Duet(0, input);
            var program1 = new Duet(1, input);
            program0.RcvQueue = program1.SndQueue;
            program1.RcvQueue = program0.SndQueue;
            while (true)
            {
                if (!program0.Run())
                    break;
                if (!program1.Run())
                    break;
                if (program0.SndQueue.Count == 0 && program1.SndQueue.Count == 0)
                    break;
            }
            return program1.NumSends;
        }


    }
    internal class Duet
    {
        private long _i;
        private readonly IDictionary<string, long> _registers;
        private readonly string[] _instructions;

        public int NumSends { get; private set; }

        public Queue<long> SndQueue { get; } = new Queue<long>();
        public Queue<long> RcvQueue { get; set; } = new Queue<long>();

        public Duet(int id, string[] input)
        {
            _instructions = input;
            _registers = _instructions.Select(i => i.Split()[1]).Distinct().ToDictionary(x => x.ToString(), x => (long)0);
            _registers.Remove("1");
            _registers["p"] = id;
        }

        /// <summary>
        /// Runs the program until it blocks in a RCV
        /// </summary>
        public bool Run()
        {
            while (_i < _instructions.Length)
            {
                var parts = _instructions[_i].Split();
                switch (parts[0])
                {
                    case "snd":
                        SndQueue.Enqueue(GetValue(parts[1]));
                        NumSends++;
                        break;
                    case "set":
                        _registers[parts[1]] = GetValue(parts[2]);
                        break;
                    case "add":
                        _registers[parts[1]] += GetValue(parts[2]);
                        break;
                    case "mul":
                        _registers[parts[1]] *= GetValue(parts[2]);
                        break;
                    case "mod":
                        _registers[parts[1]] %= GetValue(parts[2]);
                        break;
                    case "rcv":
                        if (RcvQueue.Count == 0)
                            return true;
                        _registers[parts[1]] = RcvQueue.Dequeue();
                        break;
                    case "jgz":
                        if (GetValue(parts[1]) > 0)
                        {
                            _i += GetValue(parts[2]);
                            continue;
                        }
                        break;
                }
                _i++;
            }
            return false;
        }


        private long GetValue(string value)
        {
            return _registers.ContainsKey(value) ? _registers[value] : long.Parse(value);
        }

    }
}
