using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project_Website.data
{
    public class LoginSQL : BaseDAL
    {
        public bool ValidateLogin(string email, string password)
        {
            try
            {
                String sqlStatement = "SELECT * FROM employee WHERE  email = @email AND password = @password; ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);
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
