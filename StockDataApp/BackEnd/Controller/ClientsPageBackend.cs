using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockDataApp.BackEnd.Services;
using StockDataApp.FrontEnd;

namespace StockDataApp.BackEnd.Controller
{
    public class ClientsPageBackend
    {
        public DataSet assignDataGrid()
        {
            
            Connection obj = new Connection();
            String query = "SELECT client_name,industry1,industry2,ideal_change," +
                "ideal_last_sale,ideal_volume\r\nFROM Client ";
            DataSet dataClients = obj.getDataSet(query);
            return dataClients;
        }

        public DataSet assignDataGridSpec(string filter, string sort) 
        {
            Connection obj = new Connection();
            String query = "SELECT client_name,industry1,industry2,ideal_change," +
                "ideal_last_sale,ideal_volume\r\nFROM Client ";
            DataSet dataClients = new DataSet();
            if (filter == "General" || sort == "General")
            {
                dataClients = obj.getDataSet(query);
                return dataClients;
            }
           switch (filter)
            {
                case "Ideal Change":
                    if(sort == "High to Low")
                    {
                        query = query + "\r\nORDER BY ideal_change DESC";
                    }
                    else
                    {
                        query = query + "\r\nORDER BY ideal_change ASC";
                    }
                    break;
                case "Ideal Volume":
                    if (sort == "High to Low")
                    {
                        query = query + "\r\nORDER BY ideal_volume DESC";
                    }
                    else
                    {
                        query = query + "\r\nORDER BY ideal_volume ASC";
                    }
                    break;
                case "Ideal Last Sale":
                    if (sort == "High to Low")
                    {
                        query = query + "\r\nORDER BY ideal_last_sale DESC";
                    }
                    else
                    {
                        query = query + "\r\nORDER BY ideal_last_sale ASC";
                    }
                    break;
            }
            dataClients = obj.getDataSet(query);
            return dataClients;
        }
    }
}
