using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Creatures
{
    public class Player : Creature
    {
        public Player(int health, int x, int y, int attack, string name) : base(health, attack, name, 'P')
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Bag Bag { get; } = new Bag();

        //public override void Attack(Creature opponent)
        //{

        //}



    }
}
