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
    public partial class ProductsPage : Form
    {
        public ProductsPage()
        {
            InitializeComponent();
            
        }

        private void ProductsPage_Load(object sender, EventArgs e)
        {

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
            ProductsPageBackend obj = new ProductsPageBackend();
            DataSet products = new DataSet();
            string selectedFilter = listBox1.GetItemText(listBox1.SelectedItem);
            string selectedSort = listBox2.GetItemText(listBox2.SelectedItem);
            MessageBox.Show(selectedFilter + "\nBy\n" + selectedSort);
            products = obj.assignDataGridSpec(selectedFilter, selectedSort);
            dataGridView1.DataSource = products.Tables[0];
        }

        public void giveValues()
        {
            panel2.Visible = false;
            ProductsPageBackend obj = new ProductsPageBackend();
            DataSet products = new DataSet();
            products = obj.assignDataGridSpec("General","General");
            dataGridView1.DataSource = products.Tables[0];
        }

        private void clients_Click(object sender, EventArgs e)
        {
            ClientsPage obj = new ClientsPage();
            obj.giveValues();
            obj.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            LoginPage obj = new LoginPage();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductsPageBackend obj = new ProductsPageBackend();
            string product = textBox3.Text;
            int num = obj.returnNumOfProducts(product);
            textBox3.Text = "";
            if (num == 0)
            {
                MessageBox.Show("No products found");
            }
            else
            {
                MessageBox.Show("Number of products found = " + num+"Choose a product!");
                DataSet productNames = obj.returnMatchingProducts(product);
                for (int i = 0; i < num; i++)
                {
                    string productName = productNames.Tables[0].Rows[i]["name"].ToString();
                    listBox3.Items.Add(productName);
                }
            }         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductsPageBackend obj = new ProductsPageBackend();
            Product product = new Product();
            int selectedIndex = listBox3.SelectedIndex;
            string selectedValue = listBox3.Items[selectedIndex].ToString();
            panel2.Visible = true;
            DataSet productInfo = obj.returnProductInfo(selectedValue);
            string product_id = productInfo.Tables[0].Rows[0]["product_id"].ToString();
            int _product_id = Int16.Parse(product_id);
            product.productId = _product_id;

            string Psymbol = productInfo.Tables[0].Rows[0]["symbol"].ToString();
            product.symbol = Psymbol;
            symbol.Text = Psymbol;
            
            string Pname = productInfo.Tables[0].Rows[0]["name"].ToString();
            product.name = Pname;
            productName.Text = Pname;

            string Plast_sale = productInfo.Tables[0].Rows[0]["last_sale"].ToString();
            float _last_sale = float.Parse(Plast_sale);
            product.last_sale = _last_sale;
            lastSale.Text = Plast_sale;

            string Pnet_change = productInfo.Tables[0].Rows[0]["net_change"].ToString();
            float _net_change = float.Parse(Pnet_change);
            product.net_change = _net_change;
            netChange.Text = Pnet_change;

            string Pchange_perc = productInfo.Tables[0].Rows[0]["change_perc"].ToString();
            float _change_perc = float.Parse (Pchange_perc);
            product.change_perc = _change_perc;
            changePercentage.Text = Pchange_perc;   

            string Pmarket_cap = productInfo.Tables[0].Rows[0]["market_cap"].ToString();
            if (Pmarket_cap == "NULL" || Pmarket_cap == "")
            {
                float _market_cap = 0;
                product.market_cap = _market_cap;
            }
            else
            {
                float _market_cap = float.Parse(Pmarket_cap);
                product.market_cap = _market_cap;
            }
            marketCap.Text = Pmarket_cap;

            string Pcountry = productInfo.Tables[0].Rows[0]["country"].ToString();
            if(Pcountry == "NULL" || Pcountry ==  "")
            {
                int _country = 0;
                product.country = _country;
            }
            else
            {
                int _country = Int16.Parse(Pcountry);
                product.country = _country;
            }
            

            string Pvolume = productInfo.Tables[0].Rows[0]["volume"].ToString();
            float _volume = float.Parse(Pvolume);
            product.volume = _volume;
            volume.Text= Pvolume;

            string Psector = productInfo.Tables[0].Rows[0]["sector"].ToString();
            int _sector = Int16.Parse(Psector);
            product.sector = _sector;   

            string Pindustry = productInfo.Tables[0].Rows[0]["industry"].ToString();
            product.industry = Pindustry;
            industry.Text = Pindustry;

            DataSet productClients = obj.assignClientProducts("General", Pname);
            dataGridView2.DataSource = productClients.Tables[0];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void symbol_TextChanged(object sender, EventArgs e)
        {

        }

        private void productName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastSale_TextChanged(object sender, EventArgs e)
        {

        }

        private void netChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void marketCap_TextChanged(object sender, EventArgs e)
        {

        }

        private void volume_TextChanged(object sender, EventArgs e)
        {

        }

        private void industry_TextChanged(object sender, EventArgs e)
        {

        }

        private void changePercentage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductsPageBackend obj = new ProductsPageBackend();
            Product product = new Product();
            int selectedIndex = listBox4.SelectedIndex;
            string filter = listBox4.Items[selectedIndex].ToString();
            selectedIndex = listBox3.SelectedIndex;
            string productName = listBox3.Items[selectedIndex].ToString();
            MessageBox.Show("Sort By : " + filter);
            DataSet productClients = obj.assignClientProducts(filter,productName);
            dataGridView2.DataSource = productClients.Tables[0];
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
