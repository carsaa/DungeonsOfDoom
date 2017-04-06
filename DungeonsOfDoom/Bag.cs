using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Bag: List<Item>
    {
        public int Weight { get { return this.Sum(item => item.Weight); } }
       
    }
}
