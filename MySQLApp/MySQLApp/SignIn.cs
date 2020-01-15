using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLApp
{
    public class SignIn
    {
        public string ID { get; set; }
        public string Password { get; set; }

        #region constructor
        public SignIn(string id, string password)
        {
            this.ID = id;
            this.Password = password;

            string logString = "server=localhost;database=testdb;userid=" + this.ID + ";password=" + this.Password;
            Console.WriteLine(logString);
            MySqlConnection con = null;

            try
            {
                con = new MySqlConnection(logString);
                con.Open();
                Console.WriteLine("登入成功");
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        #endregion
    }
}
