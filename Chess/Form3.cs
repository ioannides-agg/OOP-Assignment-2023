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
    public partial class Form3 : Form
    {
        DatabaseHandler DBHandler;
        public Form3()
        {
            InitializeComponent();
        }

        private void Matches_SelectedIndexChanged(object sender, EventArgs e)
        {
            Match match = Matches.SelectedItem as Match; //loadaroume to paixnidi san object typou match kai apothikeyoume ta dedomena sta textboxes
            if (match != null)
            {
                plr1.Text = match.p1;
                plr2.Text = match.p2;
                result.Text = match.result;
                date.Text = match.date.ToString();
                moves.Text = match.moveHistory;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DBHandler = DatabaseHandler.db;
            DBHandler.RefreshDB(Matches);
            Matches.DisplayMember = "name";
        }
    }
}
