namespace Chess
{
    public partial class Form1 : Form
    {
        public static String? player1name;
        public static String? player2name;

        public static Form1? form1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form1 = this;
            //arxikopoioume to database handler, wste na dhmiopurghthei to object katagrafhs ton match.
            DatabaseHandler DBHandler = new DatabaseHandler();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //dimiourgoume kai apothikeoumai se static metavlhtes ta onomata twn paiktwn gia na xrhsimopoiouthoun meta sthn forma 2
                player1name = textBox1.Text;
                player2name = textBox2.Text;
                new Form2().Show();
                this.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            //this.Visible = false;
        }
    }
}
