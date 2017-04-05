using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Teacher : Monster
    {
        public Teacher(string teacherName) : base(health: 15, attack: 4, name: teacherName, icon: 't')
        {
        }

        public override char Icon
        {
            get
            {
                return Name.ToUpper()[0];
            }
        }

        public override void Attack(Creature opponent)
        {
            opponent.Health += this.AttackStrength;
        }
    }
}
