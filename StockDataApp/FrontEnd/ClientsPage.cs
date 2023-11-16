using StockDataApp.BackEnd.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockDataApp.FrontEnd
{
    public partial class ClientsPage : Form
    {
        public ClientsPage()
        {
            InitializeComponent();
           
        }

        private void ClientsPagecs_Load(object sender, EventArgs e)
        {
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            LoginPage obj = new LoginPage();
            obj.Show();
            this.Hide();
        }

        public void giveValues()
        {
            ClientsPageBackend obj = new ClientsPageBackend();
            DataSet clients = new DataSet();
            clients = obj.assignDataGrid();
            dataGridView1.DataSource = clients.Tables[0];
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientsPageBackend obj = new ClientsPageBackend();
            DataSet clients = new DataSet();
            
            string selectedFilter = listBox1.SelectedItem.ToString();
            string selectedSort = listBox2.SelectedItem.ToString();
            MessageBox.Show(selectedFilter);
            clients = obj.assignDataGridSpec(selectedFilter,selectedSort);
            dataGridView1.DataSource = clients.Tables[0];
        }
    }
}
