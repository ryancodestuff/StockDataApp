using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDataApp.BackEnd.Controller
{
    public class User
    {        
        public int id { get; set; }       
        public string email { get; set; }        
        public string password { get; set; }       
        public string title { get; set; }        
        public string fname { get; set; }
        public string sname { get; set; }
        public string job_role { get; set; }
        
    }
}
