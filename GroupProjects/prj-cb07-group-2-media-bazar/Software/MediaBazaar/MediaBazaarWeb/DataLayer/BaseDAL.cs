using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Group_Project_Website.data
{
    public class BaseDAL
    {
        private MySqlConnection DBConnect;

        protected BaseDAL()
        {
            string DBConnectInfo = "Server=localhost;" +
                 "Uid=root;" +
                 "Database=mediabazaar;" +
                 "Pwd=;" +
                 "SslMode=none";
            this.DBConnect = new MySqlConnection(DBConnectInfo);
        }

        protected MySqlConnection GetDBConnection()
        {
            return this.DBConnect;
        }

        //Types of queries
        public long ExecuteCount(MySqlCommand sqlCountCommand)
        {
            try
            {
                this.DBConnect.Open();
                long count = (long)sqlCountCommand.ExecuteScalar();

                return count;
            }
            finally
            {
                this.DBConnect.Close();
            }
        }

        public int ExecuteNonQuery(MySqlCommand sqlNonQueryCommand)
        {
            try
            {
                
                this.DBConnect.Open();
                int numberAffectedRows = sqlNonQueryCommand.ExecuteNonQuery();

                return numberAffectedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                this.DBConnect.Close();
            }
        }

        public MySqlDataReader OpenExecuteReader(MySqlCommand sqlReaderCommand)
        {
            this.DBConnect.Open();
            MySqlDataReader reader = sqlReaderCommand.ExecuteReader();

            return reader;
        }

        public void CloseExecuteReader(MySqlDataReader reader)
        {
            if (reader != null)
                reader.Close();

            this.DBConnect.Close();
        }
    }
}
