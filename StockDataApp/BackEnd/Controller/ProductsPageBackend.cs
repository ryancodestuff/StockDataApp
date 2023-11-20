using StockDataApp.BackEnd.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace StockDataApp.BackEnd.Controller
{
    public class ProductsPageBackend
    {
        public DataSet assignDataGridSpec(string filter, string sort)
        {
            Connection obj = new Connection();
            String query = "SELECT symbol,name,last_sale,net_change,change_perc,market_cap," +
                "country,volume,industry\r\nFROM Products";
            DataSet dataProducts = new DataSet();
            if (filter == "General" || sort == "General")
            {
                dataProducts = obj.getDataSet(query);
                return dataProducts;
            }
            switch (filter)
            {
                case "Last Sale":
                    if (sort == "Low to High")
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY last_sale";
                    }
                    else
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY last_sale DESC";
                    }
                    break;
                case "Net Change":
                    if (sort == "Low to High")
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY net_change";
                    }
                    else
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY last_sale DESC";
                    }
                    break;
                case "Change Percentage":
                    if (sort == "Low to High")
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY change_perc";
                    }
                    else
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY change_perc DESC";
                    }
                    break;
                case "Market Cap":
                    if (sort == "Low to High")
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                             "country,volume,industry\r\nFROM Products\r\nORDER BY market_cap";
                    }
                    else
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                            "country,volume,industry\r\nFROM Products\r\nORDER BY market_cap DESC";
                    }
                    break;
                case "Volume":
                    if (sort == "Low to High")
                    {
                        query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                             "country,volume,industry\r\nFROM Products\r\nORDER BY volume";
                    }
                    query = "SELECT TOP 100 symbol,name,last_sale,net_change,change_perc,market_cap," +
                         "country,volume,industry\r\nFROM Products\r\nORDER BY volume DESC";
                    break;
            }
            dataProducts = obj.getDataSet(query);
            return dataProducts;
        }

        public int returnNumOfProducts(string product)
        {
            int num;
            Connection obj = new Connection();
            String query = "SELECT COUNT(*) AS COUNT\r\nFROM Products\r\n" +
                "WHERE LOWER(name) LIKE LOWER('" + product + "'+'%')";
            DataSet noOf = obj.getDataSet(query);
            string number = noOf.Tables[0].Rows[0]["COUNT"].ToString();
            num = Int16.Parse(number);
            return num;
        }

        public DataSet returnMatchingProducts(string product)
        {
            Connection obj = new Connection();
            String query = "SELECT name\r\nFROM Products\r\n" +
                "WHERE LOWER(name) LIKE LOWER('" + product + "'+'%')";
            DataSet productNames = obj.getDataSet(query);
            return productNames;
        }

        public DataSet returnProductInfo(string product)
        {
            Connection obj = new Connection();
            String query = "SELECT *\r\nFROM Products\r\n" +
                "WHERE name = '" + product + "'";
            DataSet productInfo = obj.getDataSet(query);
            return productInfo;
        }

        public DataSet assignClientProducts(string filter, string productName)
        {
            Product product = new Product();
            Connection obj = new Connection();
            DataSet productInfo = returnProductInfo(productName);
            string sector = productInfo.Tables[0].Rows[0]["sector"].ToString();
            string change = productInfo.Tables[0].Rows[0]["net_change"].ToString();
            string volume = productInfo.Tables[0].Rows[0]["volume"].ToString();
            string lastSale = productInfo.Tables[0].Rows[0]["last_sale"].ToString();


            if (filter == "General")
            {
                String query = "SELECT client_name,industry1,industry2,ideal_change,ideal_volume," +
                "ideal_last_sale\r\nFROM Client\r\nWHERE sector1 = " + sector + " OR sector2 = " + sector;
                DataSet clientProducts = obj.getDataSet(query);
                return clientProducts;
            }
            else if (filter == "By Change")
            {
                String query = "SELECT client_name,industry1,industry2,ideal_change,ideal_volume," +
                        "ideal_last_sale\r\nFROM Client\r\nWHERE sector1 = " + sector + " OR sector2 = " + sector + "" +
                        "\r\nORDER BY ABS(ideal_change - " + change + ")";
                DataSet clientProducts = obj.getDataSet(query);
                return clientProducts;
            }
            else if (filter == "By Volume")
            {
                String query = "SELECT client_name,industry1,industry2,ideal_change,ideal_volume," +
                        "ideal_last_sale\r\nFROM Client\r\nWHERE sector1 = " + sector + " OR sector2 = " + sector + "" +
                        "\r\nORDER BY ABS(ideal_volume - " + volume + ")";
                DataSet clientProducts = obj.getDataSet(query);
                return clientProducts;
            }
            else if (filter == "By Last Sale")
            {
                String query = "SELECT client_name,industry1,industry2,ideal_change,ideal_volume," +
                       "ideal_last_sale\r\nFROM Client\r\nWHERE sector1 = " + sector + " OR sector2 = " + sector + "" +
                       "\r\nORDER BY ABS(ideal_last_sale - " + lastSale + ")";
                DataSet clientProducts = obj.getDataSet(query);
                return clientProducts;
            }
            else
            {
                String query = "SELECT client_name,industry1,industry2,ideal_change,ideal_volume," +
                "ideal_last_sale\r\nFROM Client\r\nWHERE sector1 = " + sector + " OR sector2 = " + sector;
                DataSet clientProducts = obj.getDataSet(query);
                return clientProducts;
            }

        }
    }
    }
