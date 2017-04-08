using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public static class TextUtils
    {
        public static void AnimateText (this string text, int delay)
        {
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            
            Console.WriteLine();
        }
    }
}
