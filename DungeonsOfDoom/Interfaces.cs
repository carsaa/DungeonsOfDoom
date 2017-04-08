using DungeonsOfDoom.Creatures;
using DungeonsOfDoom.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public interface IAttackable
    {
        int Health { get; set; }
        string Attack(IAttackable opponent);
        string Name { get; }
        bool IsAlive { get; }
    }

    public interface IInhabitable
    {
        Monster Monster { get; set; }
        Item Item { get; set; }
    }

    public interface ICollectable
    {
       int Weight { get; set; }
       string Name { get; }
    }

}
