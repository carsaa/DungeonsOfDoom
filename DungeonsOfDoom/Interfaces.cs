using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IAttackable
    {
        int Health { get; set; }
        string Attack(IAttackable opponent);
        string Name { get; }
        bool IsAlive { get; }
    }

    interface IInhabitable
    {
        Monster Monster { get; set; }
        Item Item { get; set; }
    }

    interface ICollectable
    {
       int Weight { get; set; }
       string Name { get; }
    }

}
