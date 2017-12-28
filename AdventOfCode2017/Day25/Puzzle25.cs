using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle25
    {
        public static int Part1()
        {
            var items = new Dictionary<int, int>();
            var state = 'A';
            var currentValue = 0;
            var currentIndex = 0;
            for (var i = 0; i < 12481997; i++)
            {
                if (!items.ContainsKey(currentIndex))
                    items.Add(currentIndex, 0);

                currentValue = items[currentIndex];
                switch (state)
                {
                    case 'A':
                        if (currentValue == 0)
                        {
                            items[currentIndex] = 1;
                            currentIndex++;
                            state = 'B';
                        }
                        else
                        {
                            items[currentIndex] = 0;
                            currentIndex--;
                            state = 'C';
                        }
                        break;
                    case 'B':
                        items[currentIndex] = 1;
                        if (currentValue == 0)
                        {
                            currentIndex--;
                            state = 'A';
                        }
                        else
                        {
                            currentIndex++;
                            state = 'D';
                        }
                        break;
                    case 'C':
                        items[currentIndex] = 0;
                        currentIndex--;
                        state = currentValue == 0 ? 'B' : 'E';
                        break;
                    case 'D':
                        if (currentValue == 0)
                        {
                            items[currentIndex] = 1;
                            state = 'A';
                        }
                        else
                        {
                            items[currentIndex] = 0;
                            state = 'B';
                        }
                        currentIndex++;
                        break;
                    case 'E':
                        items[currentIndex] = 1;
                        currentIndex--;
                        state = currentValue == 0 ? 'F' : 'C';
                        break;
                    case 'F':
                        items[currentIndex] = 1;
                        currentIndex++;
                        state = currentValue == 0 ? 'D' : 'A';
                        break;
                }
            }
            return items.Values.Sum(x => x);
        }
    }
}
