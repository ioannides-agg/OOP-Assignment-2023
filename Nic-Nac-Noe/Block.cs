using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nic_Nac_Noe
{
    internal class Block
    {
        String text;
        Size Size;
        Point Location;
        Button btn;
        static GameLogic GM;

        public Block(String txt, Size sz, Point loc, Color txtColor, GameLogic gM)
        {
            this.text = txt;
            this.Size = sz;
            this.Location = loc;

            this.btn = new Button();
            this.btn.Text = text;
            this.btn.Location = Location;
            this.btn.Size = Size;
            this.btn.ForeColor = txtColor;
            this.btn.BackColor = Color.Gainsboro;
            this.btn.Font = new Font("Arial", 36);
            this.btn.Click += new EventHandler(this.buttonClick);
            Form1.game.Controls.Add(btn);
            GM = gM;
        }

        public void buttonClick(object sender, EventArgs e)
        {
            
            if (this.text == " ")
            {
                switch (GameLogic.round % 2)
                {
                    case 0:
                        this.text = "X";
                        break;
                    case 1:
                        this.text = "O";
                        break;
                }
                btn.Text = text;
                GameLogic.round++;
                GM.calculate();
                GM.test();
                GM.reset();
            }
        }

        public Button getButton() { 
            return btn; 
        }
    }
}
