using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockDataApp.BackEnd.Controller;

namespace StockDataApp.FrontEnd
{
    public partial class DashboardMain : Form
    {
        public DashboardMain()
        {
            InitializeComponent();
            profile.FlatStyle = FlatStyle.Flat;
            profile.FlatAppearance.BorderSize= 0;
            dashboard.FlatStyle = FlatStyle.Flat;
            dashboard.FlatAppearance.BorderSize = 0;
            clients.FlatStyle = FlatStyle.Flat;
            clients.FlatAppearance.BorderSize = 0;
            products.FlatStyle = FlatStyle.Flat;
            products.FlatAppearance.BorderSize = 0;
            exit.FlatStyle = FlatStyle.Flat;
            exit.FlatAppearance.BorderSize = 0;
        }

        private void profile_Click(object sender, EventArgs e)
        {
            ProfilePage obj = new ProfilePage();
            this.Hide();
            obj.Show();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {

        }

        private void clients_Click(object sender, EventArgs e)
        {

        }

        private void products_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            LoginPage obj = new LoginPage();
            this.Hide();
            obj.Show();
        }
        public void uname(String uname)
        {
            EventsBackend obj = new EventsBackend();
            int userID = obj.getUserId(uname);
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void noEvents_Click(object sender, EventArgs e)
        {

        }

        private void DashboardMain_Load(object sender, EventArgs e)
        {

        }

        public void assignMessages(int userID)
        {
            MessagesBackend obj = new MessagesBackend();
            String[][] messages = new String[5][];
            int num = obj.getNumOfMessages(userID);
            messages = obj.getMessages(userID);
            for(int i = 0;i<num;i++)
            {
                MessageBox.Show(messages[i][2]);
                switch (i)
                {
                    case 1:
                        if (Int16.Parse(messages[i][0]) == userID)
                        {
                            button1.Text= "Sent : " +messages[i][2];
                        }
                        else
                        {
                            button1.Text = "Recieved : " + messages[i][2];
                        }
                        break;
                    case 2:
                        if (Int16.Parse(messages[i][0]) == userID)
                        {
                            button2.Text = "Sent : " + messages[i][2];
                        }
                        else
                        {
                            button2.Text = "Recieved : " + messages[i][2];
                        }
                        break;
                    case 3:
                        if (Int16.Parse(messages[i][0]) == userID)
                        {
                            button3.Text = "Sent : " + messages[i][2];
                        }
                        else
                        {
                            button3.Text = "Recieved : " + messages[i][2];
                        }
                        break;
                    case 4:
                        if (Int16.Parse(messages[i][0]) == userID)
                        {
                            button4.Text = "Sent : " + messages[i][2];
                        }
                        else
                        {
                            button4.Text = "Recieved : " + messages[i][2];
                        }
                        break;
                    case 5:
                        if (Int16.Parse(messages[i][0]) == userID)
                        {
                            button5.Text = "Sent : " + messages[i][2];
                        }
                        else
                        {
                            button5.Text = "Recieved : " + messages[i][2];
                        }
                        break;

                }
            }
        }

        private void messages_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void events_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
