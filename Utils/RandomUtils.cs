﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class RandomUtils
    {
        static Random random = new Random();

        static public int GetRandomNumber(int min, int max)
        {
            int value = random.Next(min, max);
            return value;
        }

        static public bool TryPercentage(int percentage)
        {
            return random.Next(0, 100) < percentage;
        }
    }
}
