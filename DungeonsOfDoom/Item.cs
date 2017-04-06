using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : GameObject, ICollectable
    {
        public Item(string name, int weight) : base(name, 'I')
        {
            Weight = weight;
        }

        public int Weight { get; set; }

        //public int Health { get; set; }
        //public int Attack { get; set; }
        public abstract void Interaction(Player player);
    }
}
