using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public abstract class GameObject
    {
        public GameObject(string name, char icon)
        {
            Name = name;
            Icon = icon;
            Color = ConsoleColor.White;
        }

        public string Name { get; }
        virtual public char Icon { get; }

        public virtual ConsoleColor Color { get; set; }

    }
}
