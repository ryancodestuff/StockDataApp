﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using StockDataApp.FrontEnd;

namespace StockDataApp.BackEnd.Services
{
    internal class Connection
    {      
        private static SqlConnection conToDB;

        String conString = StockDataApp.Properties.Settings.Default.ConnString;

       

        public DataSet getDataSet(string query)

        {
            DataSet dataSet = new DataSet();

            using (conToDB = new SqlConnection(conString))
            {
                conToDB.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, conToDB);
                adapter.Fill(dataSet);
                conToDB.Close();
            }
            return dataSet;

        }
        
        public SqlDataReader DataReader(string Query_)
        {
            //the data reader works with SQL connection so when writing the query it can connect the database with the back-end 
            using (conToDB = new SqlConnection(conString))
            {
                conToDB.Open();

                SqlCommand cmd = new SqlCommand(Query_, conToDB);
                SqlDataReader dr = cmd.ExecuteReader();
                conToDB.Close();
                return dr;
            }
        }
        public string setUsername(string username)
        {
            return username;
        }
    }

}
