using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUs
{
    class Player : GameObject 
    {
        protected Vector velocity;
        
        protected bool isAlive;

        public readonly string playername;

        public char tag = 'I';
      
        public Vector Position
        {
            get { return position; }
        }

        public Player(string playername)
        {
            this.playername = playername;
        }     
    }

    class Imposter : Player
    {

        public Imposter(string name) : base(name)
        {

        }

        public override void Setup()
        {
            
        }
    }

    class Astronaut : Player
    {
        public Astronaut(string playername) : base(playername)
        {

        }        
    }

    class Wall : GameObject
    {
        public Wall() { }
        
        public Wall(int x, int y)
        {
            position.x = x;
            position.y = y;
        }
    }

    class EmergencyButton : GameObject
    {

    }

}
