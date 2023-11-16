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
            Random random = new Random();
            
            ProfileBackend obj = new ProfileBackend();
            int userID = obj.getUserId(uname);

            //userDetails being updated
            DataSet userData = obj.returnUserData(101);//gets userinfo dataset
            string email = userData.Tables[0].Rows[0]["email"].ToString();
            string title = userData.Tables[0].Rows[0]["title"].ToString();
            string fname = userData.Tables[0].Rows[0]["fname"].ToString();
            string sname = userData.Tables[0].Rows[0]["sname"].ToString();
            string job_role = userData.Tables[0].Rows[0]["job_role"].ToString();
            int randomNumber = random.Next(1, 10 + 1);
            string quote = obj.returnQuote(randomNumber);//gets Random quote

            //assigns values to the text boxes
            textBox2.Text = email;
            titleBox.Text = title;
            firstNameBox.Text = fname;
            secondNameBox.Text = sname;
            jobRoleBox.Text = job_role;
            quoteBox.Text = quote;

            int numOfEvents = obj.returnNumOfEvents(userID);//gets the number of events related to the user
            DataSet eventsData = obj.returnEventData(userID);
            switch (numOfEvents)
            {
                case 0:
                    event1Button.Text = "No Events";
                    event1Button.Enabled = false;
                    event2Button.Text = "No Events";
                    event2Button.Enabled = false;
                    event3Button.Text = "No Events";
                    event3Button.Enabled = false;
                    break;
                case 1:
                    event1Button.Text = eventsData.Tables[0].Rows[0]["title"].ToString();
                    event2Button.Text = "No Events";
                    event2Button.Enabled = false;
                    event3Button.Text = "No Events";
                    event3Button.Enabled = false;
                    break;
                case 2:
                    event1Button.Text = eventsData.Tables[0].Rows[0]["title"].ToString();
                    event2Button.Text = eventsData.Tables[0].Rows[1]["title"].ToString();
                    event3Button.Text = "No Events";
                    event3Button.Enabled = false;
                    break;
                default:
                    event1Button.Text = eventsData.Tables[0].Rows[0]["title"].ToString();
                    event2Button.Text = eventsData.Tables[0].Rows[1]["title"].ToString();
                    event1Button.Text = eventsData.Tables[0].Rows[2]["title"].ToString();
                    break;

            }
            

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

        

        private void messages_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void events_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void titleBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void secondNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void jobRoleBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void quoteBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
