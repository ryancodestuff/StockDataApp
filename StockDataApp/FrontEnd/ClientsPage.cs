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
using System.Xml.Linq;


namespace StockDataApp.FrontEnd
{
    public partial class ClientsPage : Form
    {
        public ClientsPage()
        {
            InitializeComponent();
            listcollection.Clear();
            foreach(string str in listBox3.Items)
            {
                listcollection.Add(str);
                
            }
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
            panel2.Visible = false;
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
            panel2.Visible=false;
            ClientsPageBackend obj = new ClientsPageBackend();
            DataSet clients = new DataSet(); 
            string selectedFilter = listBox1.GetItemText(listBox1.SelectedItem);
            string selectedSort = listBox2.GetItemText(listBox2.SelectedItem);
            MessageBox.Show(selectedFilter + "\nBy\n"+selectedSort);
            clients = obj.assignDataGridSpec(selectedFilter,selectedSort);
            dataGridView1.DataSource = clients.Tables[0];
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        List<string> listcollection = new List<string>();
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox3.Text)==false)
            {
                listBox3.Items.Clear();
                foreach(string str in listcollection)
                {
                    if(str.StartsWith(textBox3.Text))
                    {
                        listBox3.Items.Add(str);
                    }
                }
            }
            else if(textBox3.Text=="")
            {
                listBox3.Items.Clear();
                foreach (string str in listcollection)
                {
                    listBox3.Items.Add(str);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientsPageBackend obj = new ClientsPageBackend();
            panel2.Visible = true;
            int selectedIndex = listBox3.SelectedIndex;
            string selectedValue = listBox3.Items[selectedIndex].ToString();
            DataSet clientInfo = obj.returnClientInfo(selectedValue);
            MessageBox.Show("Client Name : " + selectedValue);
            string name = clientInfo.Tables[0].Rows[0]["client_name"].ToString();
            string Cindustry1 = clientInfo.Tables[0].Rows[0]["industry1"].ToString();
            string Cindustry2 = clientInfo.Tables[0].Rows[0]["industry2"].ToString();
            string ideal_change = clientInfo.Tables[0].Rows[0]["ideal_change"].ToString();
            string ideal_volume = clientInfo.Tables[0].Rows[0]["ideal_volume"].ToString();
            string ideal_last_sale = clientInfo.Tables[0].Rows[0]["ideal_last_sale"].ToString();
            clientName.Text = name;
            industry1.Text = Cindustry1;
            industry2.Text = Cindustry2;
            change.Text = ideal_change;
            volume.Text = ideal_volume;
            lastSale.Text = ideal_last_sale;
            DataSet produts = obj.returnClientProducts(name, "General");
            dataGridView2.DataSource = produts.Tables[0];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientsPageBackend obj = new ClientsPageBackend();
            int selectedIndex = listBox3.SelectedIndex;
            string selectedValue = listBox3.Items[selectedIndex].ToString();
           
            DataSet clientInfo = obj.returnClientInfo(selectedValue);
            string name = clientInfo.Tables[0].Rows[0]["client_name"].ToString();
            selectedIndex = listBox4.SelectedIndex;
            selectedValue = listBox4.Items[selectedIndex].ToString();
            MessageBox.Show("By : " + selectedValue);
            DataSet produts = obj.returnClientProducts(name,selectedValue);
            dataGridView2.DataSource = produts.Tables[0];
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            LoginPage obj = new LoginPage();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clients_Click(object sender, EventArgs e)
        {

        }

        private void products_Click(object sender, EventArgs e)
        {
            ProductsPage obj = new ProductsPage();
            obj.giveValues();
            obj.Show();
            this.Hide();
        }
    }
}
