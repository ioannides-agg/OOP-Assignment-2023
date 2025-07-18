using Chess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form2 : Form
    {
        GameManager GM;
        PlayerHandler? white; //erwthmatiko dipla apo ton typo ths metavlhths shmainei oti h sygkekrimenh metavlhth mporei na parei thn timh null
        PlayerHandler? black;


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //prosthetoume epiloges sto combo box
            comboBox1.Items.Add("White won!");
            comboBox1.Items.Add("Black won!");
            comboBox1.Items.Add("Stalemate!");
            comboBox1.Items.Add("Draw!");


            white = new PlayerHandler(Player1, plr1Time, whiteSpawn);
            white.name.Text = Form1.player1name;
            black = new PlayerHandler(Player2, plr2Time, blackSpawn);
            black.name.Text = Form1.player2name;

            GM = new GameManager(white, black, panel2);

            white.secs = GM.sec;
            white.mins = GM.min;
            white.setTime();
            black.secs = GM.sec;
            black.mins = GM.min;
            black.setTime();

            //lista olwn ton tiles
            List<Control> c = panel1.Controls.Cast<Control>().ToList(); //All tiles

            //dhmiourgoume ola ta pionia
            Pawn wAPawn = new Pawn(TileA2, Resources.whitePawn, white, "W");
            Pawn wBPawn = new Pawn(TileB2, Resources.whitePawn, white, "W");
            Pawn wCPawn = new Pawn(TileC2, Resources.whitePawn, white, "W");
            Pawn wDPawn = new Pawn(TileD2, Resources.whitePawn, white, "W");
            Pawn wEPawn = new Pawn(TileE2, Resources.whitePawn, white, "W");
            Pawn wFPawn = new Pawn(TileF2, Resources.whitePawn, white, "W");
            Pawn wGPawn = new Pawn(TileG2, Resources.whitePawn, white, "W");
            Pawn wHPawn = new Pawn(TileH2, Resources.whitePawn, white, "W");
            Pawn wQueen = new Pawn(TileD1, Resources.whiteQueen, white, "wQ");
            Pawn wKing = new Pawn(TileE1, Resources.whiteKing, white, "wK");

            Pawn wGHorse = new Pawn(TileG1, Resources.whiteHorse, white, "wH");
            Pawn wBHorse = new Pawn(TileB1, Resources.whiteHorse, white, "wH");

            Pawn wCBishop = new Pawn(TileC1, Resources.whiteBishop, white, "wB");
            Pawn wFBishop = new Pawn(TileF1, Resources.whiteBishop, white, "wB");

            Pawn wARook = new Pawn(TileA1, Resources.whiteRook, white, "wR");
            Pawn wHRook = new Pawn(TileH1, Resources.whiteRook, white, "wR");


            Pawn bAPawn = new Pawn(TileA7, Resources.blackPawn, black, "B");
            Pawn bBPawn = new Pawn(TileB7, Resources.blackPawn, black, "B");
            Pawn bCPawn = new Pawn(TileC7, Resources.blackPawn, black, "B");
            Pawn bDPawn = new Pawn(TileD7, Resources.blackPawn, black, "B");
            Pawn bEPawn = new Pawn(TileE7, Resources.blackPawn, black, "B");
            Pawn bFPawn = new Pawn(TileF7, Resources.blackPawn, black, "B");
            Pawn bGPawn = new Pawn(TileG7, Resources.blackPawn, black, "B");
            Pawn bHPawn = new Pawn(TileH7, Resources.blackPawn, black, "B");
            Pawn bQueen = new Pawn(TileD8, Resources.blackQueen, black, "bQ");
            Pawn bKing = new Pawn(TileE8, Resources.blackKing, black, "bK");

            Pawn bGHorse = new Pawn(TileG8, Resources.blackHorse, black, "bH");
            Pawn bBHorse = new Pawn(TileB8, Resources.blackHorse, black, "bH");

            Pawn bCBishop = new Pawn(TileC8, Resources.blackBishop, black, "bB");
            Pawn bFBishop = new Pawn(TileF8, Resources.blackBishop, black, "bB");

            Pawn bARook = new Pawn(TileA8, Resources.blackRook, black, "bR");
            Pawn bHRook = new Pawn(TileH8, Resources.blackRook, black, "bR");

            //prosthetoume se kathe panel pou apotelei thn skakera mas kathws kai kathe pioni to mouse up method
            foreach (var control in c)
            {
                //prosthetoume se kathe panel pou vriskete mesa sthn lista c to mouse up function
                control.MouseEnter += new EventHandler(mouseUp);
                foreach (var c2 in control.Controls.Cast<Control>().ToList())
                {
                    if (c2 is PictureBox)
                    {
                        //prosthetoume se kathe pioni pou vriskete mesa sta panels to mouse up
                        c2.MouseEnter += new EventHandler(mouseUp);
                    }
                }
            }
        }


        void mouseUp(object sender, EventArgs e) //to mouse up method, xrhsimopoieitai gia to drag and drop movement
        {
            if (GM.getCurrent().mins > 0 || GM.getCurrent().secs > 0) //an o ekastote paikths exei xrono
            {
                if (GM.getCurrent().loadedPawn != null && GM.getCurrent().isMoving) //exei fortomeno pionaki kai kounaei ayto to pionaki
                {
                    if (GM.getCurrent().loadedPawn.move(sender)) //ean h kinhsh ginei epitixos
                    {
                        Panel tile = GM.getCurrent().loadedPawn.getTile();
                        GM.AppendMoves(GM.getCurrent().loadedPawn.notation + tile.Name.Substring(tile.Name.Length - 2).ToLower()); //prosthetoume to notation tis kinhshs ston pinaka kinisewn
                        richTextBox1.Text = GM.getMoves();
                        GM.nextTurn(); //kaloume ton epomeno gyro
                        TurnCounter.Text = GM.getTurn().ToString(); //diorthonoume to label tou  gyrou
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseHandler.db.recordMatch(Player1.Text, Player2.Text, comboBox1.Text, richTextBox1.Text, GM.getTime()); //katagrafei to match
            Form1.form1.Visible = true;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e) //ayth h methodos kaleitai kathe deyterolepto 
        {
            PlayerHandler current = GM.getCurrent();
            if (current.secs == 0)
            {
                if (current.mins > 0)
                {
                current.mins = Math.Clamp(current.mins - 1, 0, GM.min); //xrhsimopoioume to clamping method giana periorisoume ta lepta ston xrono pou theloume symfwna me to GM.min
                current.secs = 60;
                }
            }

            current.secs = Math.Clamp(current.secs - 1, 0, 60);
            current.setTime();
        }
    }
}