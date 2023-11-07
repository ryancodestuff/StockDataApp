using StockDataApp.BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StockDataApp.BackEnd.Controller
{
    internal class MessagesBackend
    {
        public String[][] getMessages(int userID)
        {
            String[][] messages = new String[5][];
            int number = getNumOfMessages(userID);
            
            Connection obj = new Connection();
            String query = "SELECT TOP 5 * \r\nFROM Messages" +
                " \r\nWHERE sender_id = " + userID +
                "\r\nOR recipient_id = " + userID +
                "\r\n ORDER BY timestamp";
            DataSet messagesDat = obj.getDataSet(query);
            for(int i =0;i<number;i++)
            {
                messages[i][0] = messagesDat.Tables[0].Rows[i]["sender_id"].ToString();
                messages[i][1] = messagesDat.Tables[0].Rows[i]["recipient_id"].ToString();
                messages[i][2] = messagesDat.Tables[0].Rows[i]["text"].ToString();
            }
            return messages;
        }

        public int getNumOfMessages(int userID)
        {
            Connection obj = new Connection();
            String query = "SELECT COUNT(message_id) AS Count\r\n" +
                "FROM Messages \r\nWHERE recipient_id = " +userID+
                "\r\nOR sender_id = " + userID;
            DataSet number = obj.getDataSet(query);
            string num = number.Tables[0].Rows[0]["Count"].ToString();
            int no = Int16.Parse(num);
            return no;
        }
    }
}
