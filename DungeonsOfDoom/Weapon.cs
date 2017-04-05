using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Weapon : Item
    {
        public Weapon(int weight, string name, int attackStrength) : base(name, weight)
        {
            AttackStrength = attackStrength;
        }

        public int AttackStrength { get; set; }
    }
}
