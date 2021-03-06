﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Puzzles
{
    public class Puzzle23
    {
        public static long Part1(string[] input)
        {
            var conflagration = new Duet(0, input);
            conflagration.Run();
            return conflagration.NumMul;
        }

        public static long Part2(string[] input)
        {
            var h = 0;
            for (var b = 108400; b < 125400 + 1; b += 17)
            {
                var f = 1;

                for (var d = 2; d < b; d++)
                {
                    if (b % d != 0)
                        continue;

                    f = 0;
                    break;
                }
                if (f == 0)
                {
                    h++;
                }
            }
            /// disassembled a little more. h is just counting prime numbers between starting values of b and c
            //do
            //{
            //    f = 1;
            //    d = 2;
            //    e = 2;

            //    for (d = 2; d < b; d++) //from 2 to b (108400), increasing by 17 each loop
            //    {
            //        if (b % d != 0) //we are looking for any value d that is a factor of b. b is not prime
            //            continue;

            //        f = 0;
            //        break; //b is prime, break out
            //    }
            //    if (f == 0) //if b was prime, increase h by 1
            //    {
            //        h++; //h counts all values between 108400 and c (125400)
            //    }
            //    g = b - c; //only break out when b = c. so we count from 108400 to 125400, skipping 17 each iteration
            //    b += 17;
            //} while (g != 0);
            return h;
        }

        public static long Part2Disassembled(string[] input)
        {
            var a = 1;
            var b = 0;
            var c = 0;
            var d = 0;
            var e = 0;
            var f = 0;
            var g = 0;
            var h = 0;

            b = 84; // 1: set b 84
            c = b; // 2: set c b

            if (a != 0) // 3: jnz a 2, 4: jnz 1 5
            {
                b *= 100; // 5: mul b 100
                b += 100000; // 6: sub b -100000
                c = b; // 7: set c b
                c += 17000; // 8: sub c -17000
            }

            do
            {
                f = 1; // 9: set f 1

                do
                {
                    d = 2; // 10: set d 2
                    e = 2; // 11: set e 2

                    do
                    {
                        g = d; // 12: set g d
                        g *= e; // 13: mul g e
                        g -= b; // 14: sub g b
                        if (g != 0) // 15: jnz g 2
                        {
                            f = 0; // 16: set f 0
                        }
                        e += 1; // 17: sub e -1
                        g = e; // 18: set g e
                        g -= b; // 19: sub g b
                    } while (g != 0); // 20

                    d += 1; // 21: sub d -1
                    g = d; // 22: set g d
                    g -= b; // 23: sub g b
                } while (g != 0); // 24: jnz g -13

                if (f != 0) // 25: jnz f 2
                { 
                    h += 1; // 26: sub h -1
                }

                g = b; // 27: set g b
                g -= c; // 28: sub g c
                if (g != 0) // 29: jnz g 2
                {
                    break; // 30: jnz 1 3
                }

                b += 17; // 31: sub b -17
            } while (true); // 32: jnz 1 -23


            return h;
        }

    }
}
