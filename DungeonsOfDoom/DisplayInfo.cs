using System;

namespace DungeonsOfDoom
{
    public class DisplayInfo
    {
        public DisplayInfo(char icon, ConsoleColor color)
        {
            Icon = icon;
            Color = color;
        }
        public char Icon { get;  }
        public ConsoleColor Color { get; }
    }
}
