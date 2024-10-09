using MediaBazaar.Logic_Layer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBazaar.Data_Layer
{
    public class KeySystemData  :   BaseDAL
    {
        public bool AddKey(KeySystem k)
        {
           
            try
            {
                //Prepare query
                String sqlStatement = "INSERT INTO register_keys (register_key) VALUES (@register_key) ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@register_key", k.Key);

                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);

                return true;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                   "--This should not be happening--\n" +
                   "Unexpected result from database manager:\n" +
                   "addition of user entry results in number ");
            }

        }
        public bool MarkKeyAsUsed(string key,string used_by)
        {
            try
            {
                String sqlStatement = $"UPDATE register_keys SET used_by = '{used_by}' WHERE register_key = '{key}'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                
                
                int n = ExecuteNonQuery(sqlCommand);
                return true;
            }

            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                                        "--This should not be happening--\n" +
                                        "Unexpected result from database manager:\n" +
                                        "addition of user entry results in number ");
            }
        }
        public List<KeySystem> GetAllKeys()
        {
          
                List<KeySystem> keys = new List<KeySystem>(); ;
                try
                {
                    String sqlStatement = "SELECT * FROM register_keys;";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                    MySqlDataReader dr;

                    dr = OpenExecuteReader(sqlCommand);

                    while (dr.Read())
                    {
                        KeySystem k = new KeySystem(Convert.ToInt32(dr["id"]), dr["register_key"].ToString(), dr["used_by"].ToString());
                        keys.Add(k);
                    }
                    CloseExecuteReader(dr);
                    return keys;
                }
                catch (MySqlException ex)
                {
                    throw new ArgumentOutOfRangeException(
                      "--This should not be happening--\n" +
                      "Unexpected result from database manager:\n" +
                      "addition of user entry results in number ");
                }
            
        }
        public bool ValidateKey(string key)
        {
            try
            {
                String sqlStatement = "SELECT * FROM register_keys WHERE  register_key = @register_key AND used_by = '0'; ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@register_key", key);
                MySqlDataReader dr;
                dr = OpenExecuteReader(sqlCommand);
                if (dr.Read())
                {
                    CloseExecuteReader(dr);
                    return true;

                }
                else { CloseExecuteReader(dr); return false; }
            }

            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                                        "--This should not be happening--\n" +
                                        "Unexpected result from database manager:\n" +
                                        "addition of user entry results in number ");
            }
        }
    }
}
