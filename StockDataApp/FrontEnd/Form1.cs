using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockDataApp.BackEnd.Services;
using StockDataApp.BackEnd.Controller;

namespace StockDataApp.FrontEnd
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            LoginPageBackend obj = new LoginPageBackend();
            obj.validateUser(this,email_enter.Text,password_enter.Text);
        }

        private void email_enter_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_enter_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void makePanel2Visible()
        {
            panel2.Visible = true;
            textBox1.Visible  = true;
            button1.Visible = true;
        }
        public void makePanel2Invisible()
        {
            panel2.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            email_enter.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makePanel2Invisible();
        }

        public void closePageAndShowDashBoard()
        {
            DashboardMain obj = new DashboardMain();
            this.Hide();
            obj.Show();
            obj.uname(email_enter.Text);          
        }
    }
}
