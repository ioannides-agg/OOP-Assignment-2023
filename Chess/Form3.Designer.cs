namespace Chess
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            Matches = new ListBox();
            pageSetupDialog1 = new PageSetupDialog();
            plr1 = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            plr2 = new RichTextBox();
            label4 = new Label();
            result = new RichTextBox();
            date = new Label();
            label6 = new Label();
            label7 = new Label();
            moves = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(303, 9);
            label1.Name = "label1";
            label1.Size = new Size(182, 37);
            label1.TabIndex = 0;
            label1.Text = "Match History";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Matches
            // 
            Matches.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Matches.FormattingEnabled = true;
            Matches.ItemHeight = 21;
            Matches.Location = new Point(54, 80);
            Matches.Name = "Matches";
            Matches.Size = new Size(152, 319);
            Matches.TabIndex = 1;
            Matches.SelectedIndexChanged += Matches_SelectedIndexChanged;
            // 
            // plr1
            // 
            plr1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plr1.Location = new Point(321, 104);
            plr1.Name = "plr1";
            plr1.ReadOnly = true;
            plr1.Size = new Size(133, 24);
            plr1.TabIndex = 2;
            plr1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(321, 80);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 3;
            label2.Text = "Player one";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(321, 143);
            label3.Name = "label3";
            label3.Size = new Size(83, 21);
            label3.TabIndex = 5;
            label3.Text = "Player two";
            // 
            // plr2
            // 
            plr2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plr2.Location = new Point(321, 167);
            plr2.Name = "plr2";
            plr2.ReadOnly = true;
            plr2.Size = new Size(133, 24);
            plr2.TabIndex = 4;
            plr2.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(321, 350);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 7;
            label4.Text = "Result";
            // 
            // result
            // 
            result.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            result.Location = new Point(321, 374);
            result.Name = "result";
            result.ReadOnly = true;
            result.Size = new Size(133, 24);
            result.TabIndex = 6;
            result.Text = "";
            // 
            // date
            // 
            date.AutoSize = true;
            date.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            date.Location = new Point(321, 249);
            date.Name = "date";
            date.Size = new Size(108, 21);
            date.TabIndex = 9;
            date.Text = "DD/MM/YYYY";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(321, 228);
            label6.Name = "label6";
            label6.Size = new Size(59, 21);
            label6.TabIndex = 10;
            label6.Text = "Played:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(507, 80);
            label7.Name = "label7";
            label7.Size = new Size(99, 21);
            label7.TabIndex = 12;
            label7.Text = "MoveHistory";
            // 
            // moves
            // 
            moves.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moves.Location = new Point(507, 104);
            moves.Name = "moves";
            moves.ReadOnly = true;
            moves.Size = new Size(216, 295);
            moves.TabIndex = 11;
            moves.Text = "";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(791, 450);
            Controls.Add(label7);
            Controls.Add(moves);
            Controls.Add(label6);
            Controls.Add(date);
            Controls.Add(label4);
            Controls.Add(result);
            Controls.Add(label3);
            Controls.Add(plr2);
            Controls.Add(label2);
            Controls.Add(plr1);
            Controls.Add(Matches);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox Matches;
        private PageSetupDialog pageSetupDialog1;
        private RichTextBox plr1;
        private Label label2;
        private Label label3;
        private RichTextBox plr2;
        private Label label4;
        private RichTextBox result;
        private Label date;
        private Label label6;
        private Label label7;
        private RichTextBox moves;
    }
}