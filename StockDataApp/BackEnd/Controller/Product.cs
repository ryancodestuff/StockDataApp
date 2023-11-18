using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDataApp.BackEnd.Controller
{
    public class Product
    {
        public int productId { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public float last_sale { get; set; }
        public float net_change { get; set; }
        public float change_perc { get; set; }
        public float market_cap { get; set; }
        public int country { get; set; }
        public float volume { get; set; }
        public int sector { get; set; }
        public string industry { get; set; }


    }
}
