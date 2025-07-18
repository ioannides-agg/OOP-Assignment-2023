using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nic_Nac_Noe
{
    public partial class Form1 : Form
    {
        int n;
        const int buttonSize = 64;
        public static Form game;
        GameLogic GM;   
        public Form1()
        {
            InitializeComponent();
        }

        private void Multiplayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Error: Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Focus();
                return;
            }

            else if (!int.TryParse(richTextBox1.Text, out n))
            {
                MessageBox.Show("Error: Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Clear();
                richTextBox1.Focus();
                return;
            }

            else if (n % 2 == 0)
            {
                MessageBox.Show("Error: Please enter an odd number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Clear();
                richTextBox1.Focus();
                return;
            }

            n = Convert.ToInt32(richTextBox1.Text);
            GM = new GameLogic(n);
            game = new Form();
            game.BackColor = this.BackColor;
            game.StartPosition = FormStartPosition.CenterScreen;
            game.Size = new Size(buttonSize * n + 100 + 16, buttonSize * n + 139);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Block block = new Block(" ", new Size(buttonSize, buttonSize), new Point(buttonSize * i + 50, buttonSize * j + 50), this.BackColor, GM);
                    GM.nxn[i, j] = block;
                }
            }
            game.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
