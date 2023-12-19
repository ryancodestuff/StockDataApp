using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockDataApp.BackEnd.APIContoller;

namespace StockDataApp.FrontEnd
{
    public partial class NewsPage : Form
    {
        public NewsPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            News news = new News();
            string text = news.data();
            textBox1.Text = text;
        }
    }
}
