using System;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle20
    {
        public static int Part1(string[] input)
        {
            var allParticles = input.Select((t, i) => new Particle(t, i)).ToList();

            for (var i = 0; i < 10000; i++)
            {
                foreach (var particle in allParticles)
                {
                    particle.IncreaseTick();
                }
            }

            var closestToZero = allParticles.OrderBy(p => p.GetManhattanDistance()).First();
            return closestToZero.ParticleNumber;
        }

        public static long Part2(string[] input)
        {
            var allParticles = input.Select((t, i) => new Particle(t, i)).ToList();

            for (var i = 0; i < 10000; i++)
            {
                foreach (var particle in allParticles)
                {
                    particle.IncreaseTick();
                }

                var particleCollisions = allParticles.GroupBy(p => string.Join("", p.Position.X, p.Position.Y, p.Position.Z)).Where(c => c.Count() > 1);
                foreach (var collision in particleCollisions)
                foreach (var particle in collision)
                    allParticles.Remove(particle);

            }

            return allParticles.Count;
        }
    }

    public class Particle
    {
        public Point3D Position { get; set; }
        public Point3D Velocity { get; set; }
        public Point3D Acceleration { get; set; }
        public int ParticleNumber { get; set; }

        public Particle(string input, int particleNumber)
        {
            ParticleNumber = particleNumber;

            var positionIndex = input.IndexOf("<");
            var positionCoordinates = Array.ConvertAll(input.Substring(positionIndex + 1, input.IndexOf(">") - positionIndex - 1).Split(','), long.Parse);
            Position = new Point3D(positionCoordinates[0], positionCoordinates[1], positionCoordinates[2]);

            var velocityIndex = input.IndexOf("<", input.IndexOf("<") + 1);
            var velocityCoordinates = Array.ConvertAll(input.Substring(velocityIndex + 1, input.IndexOf(">", input.IndexOf(">") + 1) - velocityIndex - 1).Split(','), long.Parse);
            Velocity = new Point3D(velocityCoordinates[0], velocityCoordinates[1], velocityCoordinates[2]);

            var accelerationIndex = input.IndexOf("<", input.IndexOf("<", input.IndexOf("<") + 1) + 1);
            var accelerationCoordinates = Array.ConvertAll(input.Substring(accelerationIndex + 1, input.IndexOf(">", input.IndexOf(">", input.IndexOf(">") + 1) + 1) - accelerationIndex - 1).Split(','), long.Parse);
            Acceleration = new Point3D(accelerationCoordinates[0], accelerationCoordinates[1], accelerationCoordinates[2]);
        }

        public void IncreaseTick()
        {
            Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;
            Velocity.Z += Acceleration.Z;
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }

        public long GetManhattanDistance()
        {
            return Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        }
    }

    public class Point3D
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public Point3D(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
