using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQLApp
{
    class Command
    {
        public MySqlConnection con;
        public List<String> tableName = new List<string>();
        public string cmdText;
        MySqlDataReader reader = null;

        #region constructor
        public Command(MySqlConnection con)
        {
            this.con = con;
        }
        #endregion

        public void getTables()
        {
            this.cmdText = "SHOW tables";

            using (MySqlCommand cmd = new MySqlCommand(this.cmdText, this.con))
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tmp = reader.GetString(0);
                    this.tableName.Add(tmp);
                }
                reader.Close();
            }
        }
    }
}
