﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Cave: Space
    {
        public Cave(): base("Cave", '@')
        {

        }

        public override void Visit(Creature visitor)
        {
        }
    }
}
