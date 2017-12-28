using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle22
    {
        private static List<MapPoint> _mapPoints;

        public static int Part1(string[] input)
        {
            CreateMap(input);

            var currentX = input.Length / 2;
            var currentY = input.Length / 2;
            var directionFacing = 'N';
            var burstsCausingInfection = 0;

            for (var i = 0; i < 10000; i++)
            {
                var currentPoint = _mapPoints.FirstOrDefault(point => point.X == currentX && point.Y == currentY);
                if (currentPoint == null)
                {
                    currentPoint = new MapPoint()
                    {
                        X = currentX,
                        Y = currentY,
                        CurrentState = State.Clean
                    };
                    _mapPoints.Add(currentPoint);
                }

                if (currentPoint.CurrentState == State.Infected)
                {
                    switch (directionFacing)
                    {
                        case 'N':
                            directionFacing = 'E';
                            currentX += 1;
                            break;
                        case 'E':
                            directionFacing = 'S';
                            currentY += 1;
                            break;
                        case 'S':
                            directionFacing = 'W';
                            currentX -= 1;
                            break;
                        case 'W':
                            directionFacing = 'N';
                            currentY -= 1;
                            break;

                    }
                    currentPoint.CurrentState = State.Clean;
                }
                else
                {
                    switch (directionFacing)
                    {
                        case 'N':
                            directionFacing = 'W';
                            currentX -= 1;
                            break;
                        case 'E':
                            directionFacing = 'N';
                            currentY -= 1;
                            break;
                        case 'S':
                            directionFacing = 'E';
                            currentX += 1;
                            break;
                        case 'W':
                            directionFacing = 'S';
                            currentY += 1;
                            break;

                    }
                    currentPoint.CurrentState = State.Infected;
                    burstsCausingInfection++;
                }
            }

            return burstsCausingInfection;
        }

        public static int Part2(string[] input)
        {
            CreateMap(input);


            var currentX = input.Length / 2;
            var currentY = input.Length / 2;
            var directionFacing = 'N';
            var burstsCausingInfection = 0;

            for (var i = 0; i < 10000000; i++)
            {
                var currentPoint = _mapPoints.FirstOrDefault(point => point.X == currentX && point.Y == currentY);
                if (currentPoint == null)
                {
                    currentPoint = new MapPoint()
                    {
                        X = currentX,
                        Y = currentY,
                        CurrentState = State.Clean
                    };
                    _mapPoints.Add(currentPoint);
                }

                if (currentPoint.CurrentState == State.Infected)
                {
                    switch (directionFacing)
                    {
                        case 'N':
                            directionFacing = 'E';
                            currentX += 1;
                            break;
                        case 'E':
                            directionFacing = 'S';
                            currentY += 1;
                            break;
                        case 'S':
                            directionFacing = 'W';
                            currentX -= 1;
                            break;
                        case 'W':
                            directionFacing = 'N';
                            currentY -= 1;
                            break;

                    }
                    currentPoint.CurrentState = State.Flagged;
                }
                else if (currentPoint.CurrentState == State.Clean)
                {
                    switch (directionFacing)
                    {
                        case 'N':
                            directionFacing = 'W';
                            currentX -= 1;
                            break;
                        case 'E':
                            directionFacing = 'N';
                            currentY -= 1;
                            break;
                        case 'S':
                            directionFacing = 'E';
                            currentX += 1;
                            break;
                        case 'W':
                            directionFacing = 'S';
                            currentY += 1;
                            break;

                    }
                    currentPoint.CurrentState = State.Weakened;
                }
                else if (currentPoint.CurrentState == State.Flagged)
                {
                    switch (directionFacing)
                    {
                        case 'N':
                            directionFacing = 'S';
                            currentY += 1;
                            break;
                        case 'E':
                            directionFacing = 'W';
                            currentX -= 1;
                            break;
                        case 'S':
                            directionFacing = 'N';
                            currentY -= 1;
                            break;
                        case 'W':
                            directionFacing = 'E';
                            currentX += 1;
                            break;

                    }
                    currentPoint.CurrentState = State.Clean;
                }
                else if (currentPoint.CurrentState == State.Weakened)
                {
                    switch (directionFacing)
                    {
                        case 'N':
                            currentY -= 1;
                            break;
                        case 'E':
                            currentX += 1;
                            break;
                        case 'S':
                            currentY += 1;
                            break;
                        case 'W':
                            currentX -= 1;
                            break;

                    }
                    currentPoint.CurrentState = State.Infected;
                    burstsCausingInfection++;
                }
            }

            return burstsCausingInfection;
        }

        private static void CreateMap(IReadOnlyList<string> input)
        {
            _mapPoints = new List<MapPoint>();
            for (var y = 0; y < input.Count; y++)
            {
                for (var x = 0; x < input.Count; x++)
                {
                    var mapPoint = new MapPoint()
                    {
                        X = x,
                        Y = y,
                        CurrentState = input[y][x] == '#' ? State.Infected : State.Clean
                    };
                    _mapPoints.Add(mapPoint);
                }
            }
        }
    }

    public class MapPoint
    {
        public long X { get; set; }
        public long Y { get; set; }
        public State CurrentState { get; set; }
        
    }

    public enum State { Clean, Infected, Weakened, Flagged };
}
