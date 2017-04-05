using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Space : GameObject
    {
       
        public Space(string name, char icon = '.') : base(name , icon)
        {
            
        }
        public Monster Monster { get; set; }
        public Item Item { get; set; }

        virtual public void Visit(Player player)
        {
            if (Monster != null)
            {
                player.Health -= Monster.Attack;
            }
        }
    }
}
