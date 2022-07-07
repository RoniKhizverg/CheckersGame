using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class Login : Form
    {
        private static HttpClient client = new HttpClient();
        private const string BaseUrl = "https://localhost:44359/";

        Player player;

        public Login()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(BaseUrl);

        }

        private void XButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserResponse_Click(object sender, EventArgs e)
        {
            textUserResponse.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            txtPaswwordResponse.BackColor = SystemColors.Control;
        }

        private void txtPaswwordResponse_Click(object sender, EventArgs e)
        {
            txtPaswwordResponse.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            textUserResponse.BackColor = SystemColors.Control;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPaswwordResponse.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPaswwordResponse.UseSystemPasswordChar = true;
        }

        private async void BtnLogin_ClickAsync(object sender, EventArgs e)
        {

            string Name = textUserResponse.Text;
            string Password = txtPaswwordResponse.Text;
            string apiPath = $"api/TblUsers/userLogin?name={Name}&pw={Password}";

            HttpResponseMessage res = await client.GetAsync(apiPath);
            if (res.IsSuccessStatusCode)
            {
                player = await res.Content.ReadAsAsync<Player>();
                checkersBoard main = new checkersBoard(player);
                main.Show();
            }
            else
            {
                MessageBox.Show("Username or password are incorrect", "ERROR");
            }
        }







        private void txtPaswwordResponse_MouseClick(object sender, MouseEventArgs e)
        {

            if (txtPaswwordResponse.Text == "Please enter password")
            {
                txtPaswwordResponse.Text = "";
                txtPaswwordResponse.UseSystemPasswordChar = true;


            }
            if (textUserResponse.Text == "")
            {
                textUserResponse.Text = "Please enter user name";

            }



        }



        private void txtUserResponse_MouseClick(object sender, MouseEventArgs e)
        {

            if (textUserResponse.Text == "Please enter user name")
            {
                textUserResponse.Text = "";

            }
            if (txtPaswwordResponse.Text == "")
            {
                txtPaswwordResponse.UseSystemPasswordChar = false;

                txtPaswwordResponse.Text = "Please enter password";

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private  void BtnSite_ClickAsync(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://localhost:44359/Users/Create");
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://localhost:44359/Users");

        }
    }
}
