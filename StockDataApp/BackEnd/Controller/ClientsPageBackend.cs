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

        public DataSet returnClientInfo(string clientName)
        {
            Connection obj = new Connection();
            String query = "SELECT client_name,sector1,sector2,industry1,industry2,ideal_change," +
                "ideal_last_sale,ideal_volume\r\nFROM Client\r\n " +
                "WHERE client_name = '" + clientName +"'" ;
            DataSet dataClients = obj.getDataSet(query);
            return dataClients;
        }

        public DataSet returnClientProducts(string clientName,string orderBy)
        {
            Connection obj = new Connection();
            String query = "SELECT client_name,sector1,sector2,industry1,industry2,ideal_change," +
                "ideal_last_sale,ideal_volume\r\nFROM Client\r\n " +
                "WHERE client_name = '" + clientName + "'";
            DataSet clientInfo = obj.getDataSet(query);
            string Cindustry1 = clientInfo.Tables[0].Rows[0]["industry1"].ToString();
            string Cindustry2 = clientInfo.Tables[0].Rows[0]["industry2"].ToString();
            int sector1 = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["sector1"]);
            int sector2 = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["sector2"]);
            int ideal_change = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["ideal_change"]);
            int ideal_volume = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["ideal_volume"]);
            int ideal_last_sale = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["ideal_last_sale"]);
            
            string nQuery = "";
            switch(orderBy)
            {
                case "General":
                    query = "SELECT symbol,name,last_sale,net_change,change_perc,market_cap,ipo_year,volume,industry" +
                        "\r\nFROM Products\r\nWHERE sector = " + sector1 + " OR sector = " + sector2 +
                        " OR industry = '" + Cindustry1 + "' OR industry = '" + Cindustry2 + "'";
                    break;
                case "By Change":
                    query = "SELECT symbol,name,last_sale,net_change,change_perc,market_cap,ipo_year,volume,industry" +
                        "\r\nFROM Products\r\nWHERE sector = " + sector1 + " OR sector = " + sector2 +
                        " OR industry = '" + Cindustry1 + "' OR industry = '" + Cindustry2 + "'\r\n ORDER BY ABS(net_change - "+ideal_change+")";
                    break;
                case "By Volume":
                    query = "SELECT symbol,name,last_sale,net_change,change_perc,market_cap,ipo_year,volume,industry" +
                        "\r\nFROM Products\r\nWHERE sector = " + sector1 + " OR sector = " + sector2 +
                        " OR industry = '" + Cindustry1 + "' OR industry = '" + Cindustry2 + "'\r\n ORDER BY ABS(volume - " + ideal_volume + ")";
                    break;
                case "By Last Sale":
                    query = "SELECT symbol,name,last_sale,net_change,change_perc,market_cap,ipo_year,volume,industry" +
                        "\r\nFROM Products\r\nWHERE sector = " + sector1 + " OR sector = " + sector2 +
                        " OR industry = '" + Cindustry1 + "' OR industry = '" + Cindustry2 + "'\r\n ORDER BY ABS(last_sale - " + ideal_last_sale + ")";
                    break;
            }

            DataSet products = obj.getDataSet(query);
            return products;  
        }

        public int returnClientMatchingProducts(string clientName)
        {
            int num=0;
            Connection obj = new Connection();
            String query = "SELECT client_name,sector1,sector2,industry1,industry2,ideal_change," +
                "ideal_last_sale,ideal_volume\r\nFROM Client\r\n " +
                "WHERE client_name = '" + clientName + "'";
            DataSet clientInfo = obj.getDataSet(query);
            string Cindustry1 = clientInfo.Tables[0].Rows[0]["industry1"].ToString();
            string Cindustry2 = clientInfo.Tables[0].Rows[0]["industry2"].ToString();
            int sector1 = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["sector1"]);
            int sector2 = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["sector2"]);
            int ideal_change = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["ideal_change"]);
            int ideal_volume = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["ideal_volume"]);
            int ideal_last_sale = Convert.ToInt32(clientInfo.Tables[0].Rows[0]["ideal_last_sale"]);
            DataSet noOf = new DataSet();
            query = "SELECT COUNT(*) AS num\r\n" +
                "FROM Products\r\n" +
                "WHERE sector = " + sector1 +
                "\r\n AND industry = '" + Cindustry1 + "'";
            noOf = obj.getDataSet(query);
            int num1 = Convert.ToInt32(noOf.Tables[0].Rows[0]["num"]);
            query = "SELECT COUNT(*) AS num\r\n" +
                "FROM Products\r\n" +
                "WHERE sector = " + sector1 +
                "\r\n AND industry = '" + Cindustry2 + "'";
            noOf = obj.getDataSet(query);
            int num2 = Convert.ToInt32(noOf.Tables[0].Rows[0]["num"]);
            query = "SELECT COUNT(*) AS num\r\n" +
                "FROM Products\r\n" +
                "WHERE sector = " + sector2 +
                "\r\n AND industry = '" + Cindustry1 + "'";
            noOf = obj.getDataSet(query);
            int num3 = Convert.ToInt32(noOf.Tables[0].Rows[0]["num"]);
            query = "SELECT COUNT(*) AS num\r\n" +
                "FROM Products\r\n" +
                "WHERE sector = " + sector2 +
                "\r\n AND industry = '" + Cindustry2 + "'";
            noOf = obj.getDataSet(query);
            int num4 = Convert.ToInt32(noOf.Tables[0].Rows[0]["num"]);
            num = num1+num2+num3+num4;
            return num;
        }

       /* public int returnClientProducts()
        {

        }*/
    }
}
