using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle12
    {
        public static int Part1(string[] input)
        {
            var pipes = CreateConnections(input);

            var connectedToZero = pipes.Where(pipe => pipe.IsConnected("0", new List<string>())).ToList();

            return connectedToZero.Count;
        }

        public static int Part2(string[] input)
        {
            var pipes = CreateConnections(input);

            var groups = 0;
            while (pipes.Any())
            {
                var connected = pipes.Where(pipe => pipe.IsConnected(pipes[0].PipeNumber, new List<string>())).ToList();
                pipes.RemoveAll(x => connected.Contains(x));
                groups++;
            }

            return groups;
        }

        private static List<Pipe> CreateConnections(string[] input)
        {
            var pipes = (from line in input
                select line.Split(new[] { ' ' }, 3)
                into parts
                select new Pipe()
                {
                    PipeNumber = parts[0],
                    PipeConnectionNames = parts[2].Replace(",", "").Split().ToList()
                }).ToList();

            foreach (var pipe in pipes)
            {
                pipe.PipeConnections = pipes.Where(x => x.PipeConnectionNames.Contains(pipe.PipeNumber) && int.Parse(x.PipeNumber) != int.Parse(pipe.PipeNumber)).ToList();
            }

            return pipes;
        }

    }

    public class Pipe
    {
        public string PipeNumber { get; set; }
        public List<string> PipeConnectionNames { get; set; }
        public List<Pipe> PipeConnections { get; set; }

        public bool IsConnected(string pipe, List<string> pipesTested)
        {
            pipesTested.Add(PipeNumber);
            return PipeConnectionNames.Any(c => c == pipe) || PipeConnections.Where(x => !pipesTested.Contains(x.PipeNumber)).Any(c => c.IsConnected(pipe, pipesTested));
        }
    }
}
