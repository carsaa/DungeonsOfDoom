using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Room : Space
    {
        public Room() : base("Room") { }

        public override void Visit(Creature visitor)
        {
        }
    }
}
