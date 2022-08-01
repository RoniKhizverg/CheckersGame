using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class WinForm : Form
    {
        private Player player;
        public WinForm()
        {
            InitializeComponent();
        }

         
        public void decalreTheWinner(string winner)
        {
            textBox1.Text = "The winner is " + winner + "\n congratulations!!!\n";
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            Form checkersBoard = new checkersBoard(player);
            checkersBoard.Show();
            this.Close();
            textBox1.Text = "";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
