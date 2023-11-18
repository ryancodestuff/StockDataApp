using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockDataApp.FrontEnd;
using StockDataApp.BackEnd.Services;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;


namespace StockDataApp.BackEnd.Controller
{
    internal class LoginPageBackend
    {
        
        public void validateUser(LoginPage instance,String username, String password)
        {
            User user = new User();
            Connection obj = new Connection();
            bool uNameExists = checkIfUsernameExists(username);
            if (uNameExists == false)
            {
                instance.makePanel2Visible();
            }
            else
            {
                bool passExists = checkIfPasswordMatches(username, password);
                if (passExists == true)
                {
                    instance.Hide();
                    instance.closePageAndShowDashBoard();
                }
                else
                {
                    instance.makePanel2Visible();
                }
            }          
        }
        public bool checkIfUsernameExists(String username)
        {
            Connection obj = new Connection();
            String query = "SELECT *" +
                "\r\nFROM Users\r\n" +
                "WHERE email = '" + username + "'";
            DataSet uName = obj.getDataSet(query);
            string num = uName.Tables[0].Rows[0]["email"].ToString();
            if (username == num)
            {
                return true;
            }
            return false;
        }

        public bool checkIfPasswordMatches(String username, String password)
        {
            Connection obj = new Connection();
            String query = "SELECT password \r\nFROM Users\r\nWHERE email = '" + username + "';";
            DataSet data = obj.getDataSet(query);
            string pass = data.Tables[0].Rows[0]["password"].ToString();
            if (pass == password)
            {
                return true;
            }
            return false;
        }
    }
}
