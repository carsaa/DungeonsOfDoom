using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Creatures
{
    public abstract class Monster : Creature
    {
        public Monster(int health, int attack, string name, char icon) : base(health, attack, name, icon)
        {
            MonsterCounter++;
        }

        public static int MonsterCounter { get; set; }

    }
}
