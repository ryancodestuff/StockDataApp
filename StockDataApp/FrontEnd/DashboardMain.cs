using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        }
        public void uname(String uname)
        {
            EventsBackend obj = new EventsBackend();
            String[][] dataGrids = new String[5][];
            dataGrids = obj.getEvents(this,uname);
            dataGridView1.Visible = true;
            for(int i = 0;i<dataGrids.GetLength(0);i++) 
            {
                string[] dataGrid = new string[dataGrids.GetLength(1)];

                for(int j =0;j<dataGrids.GetLength(1);j++) 
                {
                    dataGrid[j] = dataGrids[i][j];
                }
                dataGridView1.Rows.Add(dataGrid);
            }
        }

        public void noEvents()
        {
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void noEvents_Click(object sender, EventArgs e)
        {

        }
    }
}
