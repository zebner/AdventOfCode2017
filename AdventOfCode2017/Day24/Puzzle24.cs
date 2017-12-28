using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle24
    {
        private static List<List<BridgeComponent>> _possibleBridges = new List<List<BridgeComponent>>();

        public static int Part1(string[] input)
        {
            _possibleBridges = new List<List<BridgeComponent>>();
            var components = new List<BridgeComponent>();
            foreach (var component in input)
            {
                var ports = component.Split('/');
                components.Add(new BridgeComponent
                {
                    PortA = int.Parse(ports[0]),
                    PortB = int.Parse(ports[1])
                });
            }

            MakeBridges(components, new List<BridgeComponent>(), 0);

            var strongestBridge = _possibleBridges.OrderByDescending(bridges => bridges.Sum(component => component.Strength())).First();

            return strongestBridge.Sum(component => component.Strength());
        }

        public static int Part2(string[] input)
        {
            var strongestLongestBridge = _possibleBridges.OrderByDescending(bridges => bridges.Count).ThenByDescending(bridges => bridges.Sum(component => component.Strength())).First();

            return strongestLongestBridge.Sum(component => component.Strength());

        }

        private static bool MakeBridges(IEnumerable<BridgeComponent> availableComponents, IEnumerable<BridgeComponent> usedComponents, int portToMatch)
        {
            var componentsCopy = availableComponents.ToList();
            var usedComponentsCopy = usedComponents.ToList();
            var possibleComponents = componentsCopy.Where(component => component.PortA == portToMatch || component.PortB == portToMatch).ToList();
            if (possibleComponents.Any())
            {
                foreach (var component in possibleComponents.ToList())
                {
                    componentsCopy.Remove(component);
                    usedComponentsCopy.Add(component);
                    _possibleBridges.Add(usedComponentsCopy.ToList());
                    var newPortToMatch = component.PortA == portToMatch ? component.PortB : component.PortA;
                    if (MakeBridges(componentsCopy, usedComponentsCopy, newPortToMatch))
                    { //last one in list. remove it so it can be reused if needed
                        usedComponentsCopy.Remove(component);
                        componentsCopy.Add(component);
                    }
                }
            }
            return true;
        }
    }

    public class BridgeComponent
    {
        public int PortA { get; set; }
        public int PortB { get; set; }

        public int Strength()
        {
            return PortA + PortB;
        }
    }
}
