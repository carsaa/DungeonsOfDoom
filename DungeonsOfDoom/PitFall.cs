using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Pitfall : Space
    {
        public Pitfall() : base ("P", ' ')
        {
            
        }

        public override void Visit(Player player)
        {
            player.Health = 0;
        }
    }
}
