using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class PlayerHandler
    {
        public Label name;
        public Label timer;
        public int mins;
        public int secs;

        public Pawn? loadedPawn; //pioni pou krataei o paikths
        public bool isMoving = false; //metavlhth pou elegxei an o paikths kounaei to pioni

        Panel SpawnPoint; //panel pou spawnarei ta pionia sto graveyard

        public PlayerHandler(Label n, Label t, Panel s) { 
            this.name = n;
            this.timer = t;
            this.SpawnPoint = s;
        }

        public void setTime() //ftiaxnei to label tou xronou
        {
            String sec = secs < 10? "0" + secs.ToString() : secs.ToString();
            timer.Text = mins.ToString() + ":" + sec;
        }

        public Panel GetSpawn() { return SpawnPoint; }
    }
}
