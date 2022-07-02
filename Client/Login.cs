using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Client
{
    public partial class Login : Form
    {
        

        public Login()
        {
            InitializeComponent();
        }
        Form checkerBoard;

        private void XButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player player = new Player { UserName = textBox1.Text , Password = textBox2.Text, NumOfGames = 0 };
            checkerBoard = new checkersBoard(player);
            checkerBoard.Show();
            //this.Close();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            string text = textBox2.Text.ToString();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (textBox2.Text == "Please enter password")
            {
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;


            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Please enter user name";

            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (textBox1.Text == "Please enter user name")
            {
                textBox1.Text = "";

            }
            if (textBox2.Text == "")
            {
                textBox2.UseSystemPasswordChar = false;

                textBox2.Text = "Please enter password";

            }
        }
    }
}
