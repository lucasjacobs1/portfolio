using LogicLayer;
using LogicLayer.CustomExceptions;
using LogicLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserData:BaseDAL, ILoginService
    {
        public bool ValidateLogin(Login login)
        {
            try
            {
                string sql = "SELECT * FROM user WHERE email = @email AND password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@email", login.Email);
                cmd.Parameters.AddWithValue("@password", login.Password);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                if (dr.Read())
                {
                    CloseExecuteReader(dr);
                    return true;
                }
                else
                {
                    CloseExecuteReader(dr);
                    return false;
                }
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
