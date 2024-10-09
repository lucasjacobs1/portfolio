using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbMethods
    {
        public MySqlConnection conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi459574;Database=dbi459574;Pwd=xDACYX8y;SslMode=None;connect timeout=30;");
                }
                return _conn;
            }
        }

        private MySqlConnection _conn;

        public void OpenConnection()
        {
            MySqlConnection.ClearAllPools();
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    return;
                }

            }
        }

        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
