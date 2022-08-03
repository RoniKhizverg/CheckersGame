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
            player = new Player();
            InitializeComponent();
        }

         
        public void decalreTheWinner(Player p)
        {
            textBox1.Text = "The winner is " + p.Name.Trim() + " congratulations!!!\n";
            player = p ;
        }
        public void decalreTheWinner(Player p, String winner)
        {
            textBox1.Text = "The winner is " + winner + " congratulations!!!\n";
            player = p;

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
