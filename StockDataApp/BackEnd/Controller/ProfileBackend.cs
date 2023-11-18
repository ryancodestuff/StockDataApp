using StockDataApp.BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockDataApp.FrontEnd;

namespace StockDataApp.BackEnd.Controller
{
    public class ProfileBackend
    {
        
        public DataSet returnUserData(int id)
        {
            Connection obj = new Connection();
            string query = "SELECT email,title,fname,sname,job_role" +
                "\r\nFROM Users" +
                "\r\nWHERE user_id ="+id;
            DataSet userData = obj.getDataSet(query);
            return userData;
        }

        public string returnQuote(int id)
        {
            Connection obj = new Connection();
            string query = "SELECT quote_content" +
                "\r\nFROM Quotes" +
                "\r\nWHERE quote_id =" + id;
            DataSet userData = obj.getDataSet(query);
            string quote = userData.Tables[0].Rows[0]["quote_content"].ToString(); 
            return quote;
        }

        public DataSet returnEventData(int id) 
        {
            Connection obj = new Connection();
            String query = "SELECT title,event_info\r\n" +
                "FROM Events\r\nWHERE users LIKE '%, " + id + ",%'" +
                "\r\nORDER BY event_datetime";
            DataSet eventData = obj.getDataSet(query);
            return eventData;
        }

        public int returnNumOfEvents(int id)
        {
            Connection obj = new Connection();
            String query = "SELECT COUNT(title) AS Count \r\n" +
                "FROM Events\r\n" +
                "WHERE users LIKE '%, " + id + ",%'";
            DataSet userID = obj.getDataSet(query);
            string num = userID.Tables[0].Rows[0]["Count"].ToString();
            int numOfEvents = Int16.Parse(num);
            return numOfEvents;
        }

        public int getUserId(string username)
        {
            Connection obj = new Connection();
            String query = "SELECT user_id\r\nFROM Users\r\n" +
                "WHERE email = '" + username + "'";
            DataSet userID = obj.getDataSet(query);
            string num = userID.Tables[0].Rows[0]["user_id"].ToString();
            int userNum = Int16.Parse(num);
            return userNum;
        }

        
    }
}
