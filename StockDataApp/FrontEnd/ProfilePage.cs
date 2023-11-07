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
    public partial class ProfilePage : Form
    {
        public ProfilePage()
        {
            InitializeComponent();
            profile.FlatStyle = FlatStyle.Flat;
            profile.FlatAppearance.BorderSize = 0;
            dashboard.FlatStyle = FlatStyle.Flat;
            dashboard.FlatAppearance.BorderSize = 0;
            clients.FlatStyle = FlatStyle.Flat;
            clients.FlatAppearance.BorderSize = 0;
            products.FlatStyle = FlatStyle.Flat;
            products.FlatAppearance.BorderSize = 0;
            exit.FlatStyle = FlatStyle.Flat;
            exit.FlatAppearance.BorderSize = 0;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }
    }
}
