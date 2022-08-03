using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Model;


namespace Client
{
    public partial class RestoreGames : Form
    {
        private clientDbDataContext _context = new clientDbDataContext();
        private Player _player;
        public RestoreGames(Player player)
        {
            this._player = player;
            InitializeComponent();
            var query = from c in _context.TblGames
                        where c.Winner == _player.Name
                        select new Game { Id = c.Id,GameID = c.GameID, Date = (DateTime)c.Date, Winner = c.Winner.Trim() };
            var results = query.ToList();
            restoreDataGrid.DataSource = results;
            restoreDataGrid.Refresh();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restoreGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (restoreDataGrid.SelectedCells == null) return;


                DataGridViewRow selectedRow = restoreDataGrid.SelectedRows[0];
                int Id = (int)selectedRow.Cells[0].Value;
                string winner = (string)selectedRow.Cells[1].Value;
                DateTime Date = (DateTime)selectedRow.Cells[2].Value;
                string gameId = (string)selectedRow.Cells[3].Value;
                Game gameObject = new Game { Id = Id, Winner = winner, Date = Date, GameID = gameId };

                this.Hide();
                checkersBoard checkersBoard = new checkersBoard(this._player, gameObject);
                checkersBoard.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose the entire row by clicking on the left side in the row");
            }
        }

       
    }
 }

    

