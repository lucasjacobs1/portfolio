using LogicLayer;
using LogicLayer.CustomExceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserManagement: BaseDAL, IUserService
    {
        public void AddUser(User user)
        {
            try
            {
                string sql = "INSERT INTO user (first_name, last_name, email, password, role_id) VALUES(@firstname, @lastname, @email, @password, @role);";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }

        public bool CheckEmailExists(string email)
        {
            try
            {
                string sql = "SELECT email FROM user WHERE email = @email;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@email", email);
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

        public User GetUserByEmail(string email)
        {
            try
            {
                string sql = "SELECT * FROM user WHERE email = @email;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@email", email);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                if (dr.Read())
                {
                    User u = new User(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["email"].ToString(), dr["password"].ToString(), Convert.ToInt32(dr["role_id"]));
                    CloseExecuteReader(dr);
                    return u;
                }
                else
                {
                    CloseExecuteReader (dr);
                    return null;
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

        public User GetUserById(int id)
        {
            try
            {
                string sql = "SELECT * FROM user WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                if (dr.Read())
                {
                    User u = new User(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["email"].ToString(), dr["password"].ToString(), Convert.ToInt32(dr["role_id"]));
                    CloseExecuteReader(dr);
                    return u;
                }
                else
                {
                    CloseExecuteReader(dr);
                    return null;
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
