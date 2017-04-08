using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    public class Bag : List<ICollectable>
    {
        public int Weight
        {
            get
            {
                return this.Sum(item => item.Weight);
            }
        }

    }
}
