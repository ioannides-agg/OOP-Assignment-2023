using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    internal class Pawn
    {
        public Panel pos;
        public PictureBox pawn;
        public PlayerHandler player;
        public String notation;
        public bool alive;

        public Pawn(Panel position, Image image, PlayerHandler plr, String n)
        {
            this.alive = true;
            this.pawn = new PictureBox(); 
            this.pos = position;
            this.pawn.BackgroundImageLayout = ImageLayout.Center;
            this.pawn.Image = image;
            this.pos.Controls.Add(this.pawn);
            this.pawn.Location = new Point(0, 0);
            this.pawn.Size = new Size(64, 64);
            this.pawn.BackColor = Color.Transparent;
            this.pawn.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pawn.MouseDown += new MouseEventHandler(mouseDown);
            this.pawn.MouseUp += new MouseEventHandler(mouseUp);
            this.player = plr;
            this.notation = n;

            GameManager.Pawns.Add(this);
        }

        public void mouseDown(object sender, EventArgs e) { 
            this.player.loadedPawn = this;//fortonei to pioni pou kratame sto player object, wste na leitourgeisei meta to mouseUp ths formas2
            this.player.isMoving = true;
            Bitmap bmp = new Bitmap(new Bitmap(pawn.Image), 64, 64); //allazoume ton kersora sto pionaki gia to effect
            Cursor.Current = new Cursor(bmp.GetHicon());
        }
        public void mouseUp(object sender, EventArgs e)
        {
            //ksekiname parallilo thread gia na mporoume na dwsoume se ayto to mouseUp function ena delay, wste na mporei na leitourghsei prwta h ypoloiph leitourgia tou drag and drop.
            Thread th = new Thread(new ThreadStart(resetMoving));
            th.Start();
        }

        private void resetMoving()
        {
            Thread.Sleep(100);
            this.player.isMoving=false;
            this.player.loadedPawn = null;
        }

        public Panel getTile()
        {
            return pos;
        }


        public bool move(object newPos) { //move function
            if (newPos is Panel) //ama to position pou parei apo to mouseUp tou dragnDrop einai panel
            {
                this.pos.Controls.Remove(this.pawn);
                this.pos = (Panel)newPos;
                this.pos.Controls.Add(this.pawn);
                this.pawn.Location = new Point(0, 0);
            }
            else if (newPos is PictureBox) { //ama to position pou parei apo to mouseUp einai allo pioni

                PictureBox enemyPawnGraphic = (PictureBox)newPos;
                Pawn? enemyPawn = null;

                foreach (Pawn p in GameManager.Pawns) //vriskei to pioni prwta apo to grafiko
                {
                    if (p.pos == enemyPawnGraphic.Parent)
                    {
                        enemyPawn = p;
                        break;
                    }
                }
                try
                {
                    if (enemyPawn.player != this.player && enemyPawn.alive) //an to pioni den einai tou idio paikth tote mporei na to faei
                    {
                        this.pos.Controls.Remove(this.pawn);
                        this.pos = enemyPawn.pos;
                        enemyPawn.Captured();
                        this.pos.Controls.Add(this.pawn);
                        this.pawn.Location = new Point(0, 0);
                    }
                    else return false;
                } catch(Exception e) {
                    MessageBox.Show("Something went wrong with selecting a move, try again.");
                    return false;
                }

            }

            return true;
        }

        public void Captured() //methodos pou kalleitai sto pioni pou trogetai wste na prosthethei sto plai
        {
            this.alive = false;
            this.pos.Controls.Remove(this.pawn);
            this.pos = GameManager.graveyard;
            this.pos.Controls.Add(this.pawn);
            this.pawn.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pawn.Size = new Size(36, 36);
            this.pawn.Location = player.GetSpawn().Location;
            player.GetSpawn().Location = new Point(player.GetSpawn().Location.X, player.GetSpawn().Location.Y + 36);
            this.pawn.MouseDown -= new MouseEventHandler(mouseDown);
            this.pawn.MouseUp -= new MouseEventHandler(mouseUp);
        }
    }
}
