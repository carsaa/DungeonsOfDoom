using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    static class RandomUtils
    {
        static Random randomUtils = new Random();
        static public int GetRandomNumber(int min, int max)
        {
            int value = randomUtils.Next(min, max);
            return value;
        }

        //static public bool 
    }
}
