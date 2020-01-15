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
        public bool Pass = false;

        #region constructor
        public SignIn(string id, string password)
        {
            this.ID = id;
            this.Password = password;


            string logString = "server=localhost;database=testdb;userid=" + this.ID + ";password=" + this.Password;
            string cmdText;
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                con = new MySqlConnection(logString);
                con.Open();
                Console.WriteLine("登入成功");
                Console.WriteLine("----------");
            }

            catch (MySqlException err)
            {
                this.Pass = false;
                Console.WriteLine("登入失敗");
                //Console.WriteLine(err);
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
