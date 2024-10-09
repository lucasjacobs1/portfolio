
using LogicLayer.Models;
using LogicLayer.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            this.dbMethods = new DbMethods();
        }
        MySqlDataReader reader;
        public DbMethods dbMethods { get; }

        public List<User> FindAllCandidatesByRole()
        {
            User requestedCandidate;
            List<User> can = new List<User>();
            try
            {
                string sql = "SELECT * FROM user  WHERE role = 3";
                dbMethods.OpenConnection();
                MySqlCommand command = new MySqlCommand(sql, dbMethods.conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestedCandidate = new User();
                    requestedCandidate.Id = Convert.ToInt32(reader["id"]);
                    requestedCandidate.FirstName = Convert.ToString(reader["first_name"]);
                    requestedCandidate.LastName = Convert.ToString(reader["last_name"]);
                    requestedCandidate.Email = Convert.ToString(reader["email"]);
                    requestedCandidate.Password = Convert.ToString(reader["password"]);
                    requestedCandidate.Role = Role.Candidate;


                    can.Add(requestedCandidate);
                }
                return can;
            }
            catch(Exception ex)
            {
                return can;
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }

        public User GetSpecificRecruiter(int recruiter)
        {
            User requestedRecruiter = new User();
            MySqlCommand cmd = new MySqlCommand("SELECT u.* FROM `user` AS u WHERE u.id = @ID", dbMethods.conn);
            cmd.Parameters.AddWithValue("@ID", recruiter);
            dbMethods.OpenConnection();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                requestedRecruiter.Id = Convert.ToInt32(reader["id"]);
                requestedRecruiter.FirstName = Convert.ToString(reader["first_name"]);
                requestedRecruiter.LastName = Convert.ToString(reader["last_name"]);
                requestedRecruiter.Email = Convert.ToString(reader["email"]);
                requestedRecruiter.Password = Convert.ToString(reader["password"]);
                requestedRecruiter.Role = Role.Recruiter;
            }
            dbMethods.CloseConnection();
            return requestedRecruiter;
        }

        public User GetSpecificCandidate(int candidate)
        {
            User requestedCandidate = new User();
            MySqlCommand cmd = new MySqlCommand("SELECT u.* FROM `user` AS u WHERE u.id = @ID", dbMethods.conn);
            cmd.Parameters.AddWithValue("@ID", candidate);
            dbMethods.OpenConnection();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                requestedCandidate.Id = Convert.ToInt32(reader["id"]);
                requestedCandidate.FirstName = Convert.ToString(reader["first_name"]);
                requestedCandidate.LastName = Convert.ToString(reader["last_name"]);
                requestedCandidate.Email = Convert.ToString(reader["email"]);
                requestedCandidate.Password = Convert.ToString(reader["password"]);
                requestedCandidate.Role = Role.Candidate;
            }
            dbMethods.CloseConnection();
            return requestedCandidate;
        }

        public User GetSpecificRecruiterByEmail(string email)
        {
            User substitudeRecruiter = new User();
            MySqlCommand cmd = new MySqlCommand("SELECT u.* FROM `user` as u WHERE u.email = @EMAIL", dbMethods.conn);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            dbMethods.OpenConnection();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                substitudeRecruiter.Id = Convert.ToInt32(reader["id"]);
                substitudeRecruiter.FirstName = Convert.ToString(reader["first_name"]);
                substitudeRecruiter.LastName = Convert.ToString(reader["last_name"]);
                substitudeRecruiter.Email = Convert.ToString(reader["email"]);
                substitudeRecruiter.Password = Convert.ToString(reader["password"]);
                substitudeRecruiter.Role = Role.Recruiter;
            }
            dbMethods.CloseConnection();
            return substitudeRecruiter;
        }

        public User GetCandidateUserByApplicationIdFromAppointment(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM appointment JOIN applications on appointment.application_id = applications.id JOIN user on applications.candidate_id = user.id where applications.id = @id", dbMethods.conn);
                cmd.Parameters.AddWithValue("@id", id);
                dbMethods.OpenConnection();
                User user = new User();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.FirstName = reader.GetString("first_name");
                        user.LastName = reader.GetString("last_name");
                        user.Email = reader.GetString("email");
                        user.Password = reader.GetString("password");
                    }
                }
                return user;
            }


            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }

        public User GetRecruiterUserByApplicationIdFromAppointment(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM appointment JOIN applications on appointment.application_id = applications.id JOIN user on applications.recruiter_id = user.id where applications.id = @id", dbMethods.conn);
                cmd.Parameters.AddWithValue("@id", id);
                dbMethods.OpenConnection();
                User user = new User();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.FirstName = reader.GetString("first_name");
                        user.LastName = reader.GetString("last_name");
                        user.Email = reader.GetString("email");
                        user.Password = reader.GetString("password");
                    }
                }
                return user;
            }


            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }
    }
}
