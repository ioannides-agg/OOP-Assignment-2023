using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chess
{
    internal class DatabaseHandler
    {
        String connString = $"Data source=chess.db;Version=3;";
        SQLiteConnection conn;
        public static DatabaseHandler db;

        public DatabaseHandler()
        {
            db = this; //pairnoume static reference sto object pou ftiaxnoume sthn forma 1 wste na exoume ena enoieo database handler

            //dhmiourgoume to table
            conn = new SQLiteConnection(connString);
            conn.Open();
            String createTable = "Create table if not exists MatchHistory(" +
            "id integer primary key autoincrement," +
            "Player1 Text," +
            "Player2 Text," +
            "Result Text," +
            "MoveHistory Text," +
            "Date Datetime)";
            SQLiteCommand cmd = new SQLiteCommand(createTable, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RefreshDB(ListBox lb) //refresh methodos gia reloading tou database meta apo kathe entry
        {
            conn.Open();
            String selectPlayersSQL = "Select id,Player1,Player2,Result,MoveHistory,Date from MatchHistory";
            SQLiteCommand command2 = new SQLiteCommand(selectPlayersSQL, conn);
            SQLiteDataReader sQLiteDataReaderreader = command2.ExecuteReader();
            lb.Items.Clear();
            while (sQLiteDataReaderreader.Read())
            {
                Match match = new Match();
                match.id = sQLiteDataReaderreader.GetInt32(0);
                match.p1 = sQLiteDataReaderreader.GetString(1);
                match.p2 = sQLiteDataReaderreader.GetString(2);
                match.result = sQLiteDataReaderreader.GetString(3);
                match.moveHistory = sQLiteDataReaderreader.GetString(4);
                match.date = sQLiteDataReaderreader.GetDateTime(5);
                match.name = match.p1 + " vs " + match.p2;

                lb.Items.Add(match);

            }
            conn.Close();
        }

        public void recordMatch(String p1, String p2, String result, String moves, DateTime date) { //katagrafh match
            conn.Open();
            String insertSQL = "Insert into MatchHistory(" +
                "Player1,Player2,Result,MoveHistory,Date) " +
                "values(@p1,@p2,@result,@moves,@date)";
            SQLiteCommand command = new SQLiteCommand(insertSQL, conn);
            command.Parameters.AddWithValue("p1", p1);
            command.Parameters.AddWithValue("p2", p2);
            command.Parameters.AddWithValue("result", result);
            command.Parameters.AddWithValue("moves", moves);
            command.Parameters.AddWithValue("date", date);
            int rowsInserted = command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
