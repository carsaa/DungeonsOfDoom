﻿using DungeonsOfDoom.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Spaces
{
    class Pitfall : Space
    {
        public Pitfall() : base ("Pitfall", ' ')
        {
            
        }

        public override void Visit(Creature visitor)
        {
            visitor.Health = 0;
        }
    }
}
