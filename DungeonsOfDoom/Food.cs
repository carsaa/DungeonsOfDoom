using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Food: Item
    {
        public Food(string name, int healthGain, int weight) : base(name, weight)
        {
            HealthGain = healthGain;
        }
        public int HealthGain { get;  }

        public override void Interaction(Player player)
        {
            player.Health += this.HealthGain;
        }
    }
}
