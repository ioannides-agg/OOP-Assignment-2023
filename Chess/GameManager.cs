using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class GameManager
    {
        public readonly int min = 10;
        public readonly int sec = 60;

        DateTime dateTime = DateTime.Now;

        public static List<Pawn> Pawns = new List<Pawn>(); //lista apo ola ta pionia
        public static Panel? graveyard; //to panel tou nekrotafiou
        public PlayerHandler? player1;
        public PlayerHandler? player2;
        PlayerHandler? current; //twrinos paiktis

        String? Moves; //oles oi kiniseis
        int Round = 1;

        public GameManager(PlayerHandler p1, PlayerHandler p2, Panel g) { 
            //kanoume assign tous paiktes
            this.player1 = p1;
            this.player2 = p2;
            this.current = p1;
            graveyard = g;
        }

        public PlayerHandler getCurrent() { return current; } //epistrefoume ton paikth pou paizei twra

        public String getMoves() { return Moves.Substring(0, Moves.Length - 2); } //xrhsimopoioumai to substring gia na kopsoume to telytaio komma
        public void AppendMoves(String move) {  Moves += move + ", "; } //prosthetoume kinhseis sthn lista kinisewn mazi me ena koma

        public void nextTurn() { //allazoume seira
            Round++; //ayksanoume ton gyro
            current = current == player1 ? player2 : player1; //an current player == player 1 tote kane ton current player player2 alliws kantwn player 1

            player1.name.BorderStyle = current == player1 ? BorderStyle.FixedSingle : BorderStyle.None; //ftiaxnoume to border ston plr1
            player2.name.BorderStyle = current == player2 ? BorderStyle.FixedSingle : BorderStyle.None; //ftiaxnoume to border ston plr2
        }

        public DateTime getTime() { return DateTime.Now;} //epistrefei thn shmerinh hmeromhnia

        public int getTurn() { return Round; } //epistrefei ton gyro
    }
}
