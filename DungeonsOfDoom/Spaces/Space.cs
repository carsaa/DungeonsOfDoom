using DungeonsOfDoom.Creatures;
using DungeonsOfDoom.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Spaces
{
    public abstract class Space : GameObject
    {
       
        public Space(string name, char icon = '.') : base(name , icon)
        {
            
        }
        public Monster Monster { get; set; }
        public Item Item { get; set; }

        abstract public void Visit(Creature visitor);

        public override char Icon
        {
            get
            {
                char value;
                if (Monster != null)
                    value = Monster.Icon;
                else if (Item != null)
                   value = Item.Icon;
                else
                   value = base.Icon;
                return value;
                 
            }
            
        }

    }
}
