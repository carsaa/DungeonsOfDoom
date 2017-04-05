using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class GameObject
    {
        public GameObject(string name, char icon)
        {
            Name = name;
            Icon = icon;
        }

        public string Name { get; }
        public char Icon { get; }
    }
}
