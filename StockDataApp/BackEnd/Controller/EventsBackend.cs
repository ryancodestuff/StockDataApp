using StockDataApp.BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using StockDataApp.FrontEnd;

namespace StockDataApp.BackEnd.Controller
{
    internal class EventsBackend
    {

        public String[][] getEvents(DashboardMain instance,String username)
        {
            String[][] events = new String[5][];
            Connection obj = new Connection();
            int userID = getUserId(username);
            int numOfEvents = getNumberOfEvents(userID);
            if(numOfEvents == 0)
            {
                instance.noEvents();
                return events;
            }
            String query = "SELECT title,description,event_datetime \r\n" +
                "FROM Events\r\nWHERE users " +
                "LIKE '%,"+userID+",%'";
            DataSet data = obj.getDataSet(query);
            for(int i =0;i<numOfEvents;i++)
            {
                events[i][0] = data.Tables[0].Rows[0]["title"].ToString();
                events[i][1] = data.Tables[0].Rows[0]["description"].ToString();
                events[i][2] = data.Tables[0].Rows[0]["event_datetime"].ToString();
            }
            return events;
        }

        public int getUserId(String username)
        {
            Connection obj = new Connection();
            String query = "SELECT user_id FROM Users WHERE email = '" + username + "'";
            DataSet userID = obj.getDataSet(query);
            string num = userID.Tables[0].Rows[0]["user_id"].ToString();
            int idNum = Int16.Parse(num);
            return idNum;
        }

        public int getNumberOfEvents(int id)
        {
            Connection obj = new Connection();
            String query = "SELECT COUNT(title) \r\n" +
                "FROM Events\r\n" +
                "WHERE users LIKE '%," + id + ",%'";
            DataSet userID = obj.getDataSet(query);
            string num = userID.Tables[0].Rows[0]["user_id"].ToString();
            int numOfEvents = Int16.Parse(num);
            return numOfEvents;
        }
    }
}
