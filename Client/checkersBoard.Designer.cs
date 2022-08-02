namespace Client
{
    partial class checkersBoard
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
            this.XButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ScoreLableBlack = new System.Windows.Forms.Label();
            this.ScoreLableWhite = new System.Windows.Forms.Label();
            this.nameTextBox1 = new System.Windows.Forms.TextBox();
            this.nameTextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGamesList = new System.Windows.Forms.Button();
            this.restoreGameBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // XButton
            // 
            this.XButton.BackColor = System.Drawing.SystemColors.Control;
            this.XButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XButton.FlatAppearance.BorderSize = 0;
            this.XButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XButton.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XButton.ForeColor = System.Drawing.Color.Maroon;
            this.XButton.Location = new System.Drawing.Point(940, -5);
            this.XButton.Margin = new System.Windows.Forms.Padding(4);
            this.XButton.Name = "XButton";
            this.XButton.Size = new System.Drawing.Size(40, 39);
            this.XButton.TabIndex = 1;
            this.XButton.Text = "X";
            this.XButton.UseVisualStyleBackColor = false;
            this.XButton.Click += new System.EventHandler(this.XButton_Click);
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(660, 552);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 39);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "START GAME";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 546);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources.blackSoldier;
            this.pictureBox1.Location = new System.Drawing.Point(692, 57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Client.Properties.Resources.whiteSoldier;
            this.pictureBox2.Location = new System.Drawing.Point(692, 236);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // ScoreLableBlack
            // 
            this.ScoreLableBlack.AutoSize = true;
            this.ScoreLableBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLableBlack.Location = new System.Drawing.Point(767, 73);
            this.ScoreLableBlack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLableBlack.Name = "ScoreLableBlack";
            this.ScoreLableBlack.Size = new System.Drawing.Size(27, 29);
            this.ScoreLableBlack.TabIndex = 6;
            this.ScoreLableBlack.Text = "0";
            // 
            // ScoreLableWhite
            // 
            this.ScoreLableWhite.AutoSize = true;
            this.ScoreLableWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLableWhite.Location = new System.Drawing.Point(767, 255);
            this.ScoreLableWhite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLableWhite.Name = "ScoreLableWhite";
            this.ScoreLableWhite.Size = new System.Drawing.Size(27, 29);
            this.ScoreLableWhite.TabIndex = 7;
            this.ScoreLableWhite.Text = "0";
            // 
            // nameTextBox1
            // 
            this.nameTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.nameTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox1.ForeColor = System.Drawing.Color.Maroon;
            this.nameTextBox1.Location = new System.Drawing.Point(721, 305);
            this.nameTextBox1.Name = "nameTextBox1";
            this.nameTextBox1.ReadOnly = true;
            this.nameTextBox1.Size = new System.Drawing.Size(239, 25);
            this.nameTextBox1.TabIndex = 8;
            // 
            // nameTextBox2
            // 
            this.nameTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.nameTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox2.ForeColor = System.Drawing.Color.Maroon;
            this.nameTextBox2.Location = new System.Drawing.Point(692, 126);
            this.nameTextBox2.Name = "nameTextBox2";
            this.nameTextBox2.ReadOnly = true;
            this.nameTextBox2.Size = new System.Drawing.Size(259, 25);
            this.nameTextBox2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(609, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Maroon;
            this.textBox3.Location = new System.Drawing.Point(712, 342);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(197, 25);
            this.textBox3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Num of games:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Num of games:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(712, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(197, 25);
            this.textBox1.TabIndex = 17;
            // 
            // btnGamesList
            // 
            this.btnGamesList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGamesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGamesList.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGamesList.Location = new System.Drawing.Point(647, 470);
            this.btnGamesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGamesList.Name = "btnGamesList";
            this.btnGamesList.Size = new System.Drawing.Size(232, 53);
            this.btnGamesList.TabIndex = 19;
            this.btnGamesList.Text = "LIST OF GAMES";
            this.btnGamesList.UseVisualStyleBackColor = true;
            this.btnGamesList.Click += new System.EventHandler(this.btnGamesList_Click);
            // 
            // restoreGameBtn
            // 
            this.restoreGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restoreGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreGameBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreGameBtn.Location = new System.Drawing.Point(647, 395);
            this.restoreGameBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.restoreGameBtn.Name = "restoreGameBtn";
            this.restoreGameBtn.Size = new System.Drawing.Size(232, 53);
            this.restoreGameBtn.TabIndex = 20;
            this.restoreGameBtn.Text = "RESTORE GAME";
            this.restoreGameBtn.UseVisualStyleBackColor = true;
            this.restoreGameBtn.Click += new System.EventHandler(this.restoreGameBtn_Click);
            // 
            // checkersBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(979, 629);
            this.Controls.Add(this.restoreGameBtn);
            this.Controls.Add(this.btnGamesList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox2);
            this.Controls.Add(this.nameTextBox1);
            this.Controls.Add(this.ScoreLableWhite);
            this.Controls.Add(this.ScoreLableBlack);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.XButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "checkersBoard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "checkersBoard";
            this.Load += new System.EventHandler(this.checkersBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button XButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel panel1;
				private System.Windows.Forms.PictureBox pictureBox1;
				private System.Windows.Forms.PictureBox pictureBox2;
				private System.Windows.Forms.Label ScoreLableBlack;
				private System.Windows.Forms.Label ScoreLableWhite;
        private System.Windows.Forms.TextBox nameTextBox1;
        private System.Windows.Forms.TextBox nameTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGamesList;
        private System.Windows.Forms.Button restoreGameBtn;
    }
}