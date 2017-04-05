using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Creature : GameObject
    {
        public Creature(int health, int attack, string name, char icon) : base(name, icon)
        {
            Health = health;
            Attack = attack;
        }

        public int Health { get; set; }
        public int Attack { get; set; }
        public bool IsAlive { get { return Health > 0; } }
    }
}
