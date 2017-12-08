using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle7
    {
        public static void Part1()
        {
            var input = File.ReadAllLines("Inputs/Puzzle7.txt");
            var allDiscs = new List<Disc>();
            CreateStructure(input, allDiscs);

            var topDisc = allDiscs.First(d => d.Parent == null);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 7A answer is {topDisc.Name}");
        }

        public static void Part2()
        {
            var input = File.ReadAllLines("Inputs/Puzzle7.txt");
            var allDiscs = new List<Disc>();
            CreateStructure(input, allDiscs);

            Disc unbalancedDisc = null;
            foreach (var disc in allDiscs)
            {
                var weightGroups = disc.Children.GroupBy(c => c.TotalWeightOfTower());
                if (weightGroups.Count() > 1) //something is unbalanced
                {
                    unbalancedDisc = weightGroups.FirstOrDefault(x => x.Count() == 1).First();
                    break;
                }
            }

            //we now have the disc that is unbalanced. find the siblings weight and compare
            var siblings = unbalancedDisc.Parent.Children.Where(x => x.Name != unbalancedDisc.Name);
            var requiredWeightOfTower = siblings.First().TotalWeightOfTower();
            var requiredWeight = unbalancedDisc.Weight + (requiredWeightOfTower - unbalancedDisc.TotalWeightOfTower());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Puzzle 7B answer is {requiredWeight}");
        }

        private static void CreateStructure(IEnumerable<string> input, ICollection<Disc> allDiscs)
        {
            foreach (var line in input) //create disc with children
            {
                var discParts = line.Split(new[] { ' ' }, 4);

                var disc = new Disc
                {
                    Name = discParts[0],
                    Weight = int.Parse(discParts[1].Replace("(", "").Replace(")", ""))
                };
                if (discParts.Length > 2)
                {
                    var children = discParts[3].Split(',');
                    disc.ChildrenNames.AddRange(children.Select(x => x.Trim()));
                }
                allDiscs.Add(disc);
            }

            foreach (var disc in allDiscs) //set children
            {
                if (!disc.ChildrenNames.Any())
                    continue;

                foreach (var name in disc.ChildrenNames)
                {
                    disc.Children.Add(allDiscs.First(x => x.Name == name));
                }
            }

            foreach (var disc in allDiscs) // set all parents
            {
                disc.Parent = allDiscs.FirstOrDefault(d => d.Children.Select(x => x.Name).Contains(disc.Name));
            }
        }

        public class Disc
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public List<Disc> Children { get; set; }
            public List<string> ChildrenNames { get; set; }
            public Disc Parent { get; set; }

            public Disc()
            {
                Children = new List<Disc>();
                ChildrenNames = new List<string>();
            }

            public int TotalWeightOfTower()
            {
                return Weight + Children.Sum(c => c.TotalWeightOfTower());
            }

        }

    }
}
