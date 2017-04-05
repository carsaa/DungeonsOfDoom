using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Monster : Creature
    {
        public Monster(int health, int attack, string name) : base(health, attack, name, 'M')
        {

        }

    }
}
