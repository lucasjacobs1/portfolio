using LogicLayer.Models;
using LogicLayer.Models.Enums;
using LogicLayer.Repositories;
using MySql.Data.MySqlClient;

using System.Diagnostics;

namespace DataAccessLayer.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private MySqlDataReader reader;
        public DbMethods dbMethods { get; }

        public AppointmentRepository()
        {
            this.dbMethods = new DbMethods();
        }


        public GetAppointmentsResponse getAppointments()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * FROM appointment;", dbMethods.conn);
                dbMethods.OpenConnection();
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                List<Appointment> appointments = new List<Appointment>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.Id = reader.GetInt32("id");
                        appointment.RecruiterId = reader.GetInt32("recruiter_id");
                        appointment.ApplicationId = reader.GetInt32("application_id");
                        appointment.StartDate = reader.GetDateTime("start_date");
                        appointment.EndDate = reader.GetDateTime("end_date");
                        appointment.Subject = reader.GetString("subject");
                        appointment.Body = reader.GetString("body");
                        appointment.Location = reader.GetString("location");
                        appointments.Add(appointment);

                    }
                }
                response.Appointments = appointments;
                return response;
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

        public GetAppointmentsResponse getAppointmentsFilterByDateAscending()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * FROM appointment ORDER BY start_date ASC;", dbMethods.conn);
                dbMethods.OpenConnection();
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                List<Appointment> appointments = new List<Appointment>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.Id = reader.GetInt32("id");
                        appointment.RecruiterId = reader.GetInt32("recruiter_id");
                        appointment.ApplicationId = reader.GetInt32("application_id");
                        appointment.StartDate = reader.GetDateTime("start_date");
                        appointment.EndDate = reader.GetDateTime("end_date");
                        appointment.Subject = reader.GetString("subject");
                        appointment.Body = reader.GetString("body");
                        appointment.Location = reader.GetString("location");
                        appointments.Add(appointment);
                    }
                }
                response.Appointments = appointments;
                return response;
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

        public GetAppointmentsResponse getAppointmentsFilterByDateDecending()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * FROM appointment ORDER BY start_date DESC;", dbMethods.conn);
                dbMethods.OpenConnection();
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                List<Appointment> appointments = new List<Appointment>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.Id = reader.GetInt32("id");
                        appointment.RecruiterId = reader.GetInt32("recruiter_id");
                        appointment.ApplicationId = reader.GetInt32("application_id");
                        appointment.StartDate = reader.GetDateTime("start_date");
                        appointment.EndDate = reader.GetDateTime("end_date");
                        appointment.Subject = reader.GetString("subject");
                        appointment.Body = reader.GetString("body");
                        appointment.Location = reader.GetString("location");
                        appointments.Add(appointment);
                    }
                }
                response.Appointments = appointments;
                return response;
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

        public GetAppointmentsResponse GetAppointmentsByRecruiterId(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * FROM appointment WHERE recruiter_id = @id;", dbMethods.conn);
                cmd.Parameters.AddWithValue("@id", id);
                dbMethods.OpenConnection();
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                List<Appointment> appointments = new List<Appointment>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.Id = reader.GetInt32("id");
                        appointment.RecruiterId = reader.GetInt32("recruiter_id");
                        appointment.ApplicationId = reader.GetInt32("application_id");
                        appointment.StartDate = reader.GetDateTime("start_date");
                        appointment.EndDate = reader.GetDateTime("end_date");
                        appointment.Subject = reader.GetString("subject");
                        appointment.Body = reader.GetString("body");
                        appointment.Location = reader.GetString("location");
                        appointments.Add(appointment);

                    }
                }
                response.Appointments = appointments;
                return response;
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

        public GetAppointmentsResponse GetAppointmentsBySubjectName(string subject)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand($"Select * FROM appointment WHERE subject LIKE '%{subject}%';", dbMethods.conn);
                //cmd.Parameters.AddWithValue(appointment.Subject, id);
                dbMethods.OpenConnection();
                GetAppointmentsResponse response = new GetAppointmentsResponse();
                List<Appointment> appointments = new List<Appointment>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment getappointment = new Appointment();
                        getappointment.Id = reader.GetInt32("id");
                        getappointment.RecruiterId = reader.GetInt32("recruiter_id");
                        getappointment.ApplicationId = reader.GetInt32("application_id");
                        getappointment.StartDate = reader.GetDateTime("start_date");
                        getappointment.EndDate = reader.GetDateTime("end_date");
                        getappointment.Subject = reader.GetString("subject");
                        getappointment.Body = reader.GetString("body");
                        getappointment.Location = reader.GetString("location");
                        appointments.Add(getappointment);

                    }
                }
                response.Appointments = appointments;
                return response;
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

     


      

        public AppointmentLink GetAppointmentLink(LinkValidation linkValidation)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT `id`, `usernameHashed`, `identifierHashed`, `status` " +
                    "FROM `appointments_links`" +
                    " WHERE identifierHashed = @IDENTIFIERHASHED AND usernameHashed = @USERNAMEHASHED"
                     , dbMethods.conn);

                cmd.Parameters.AddWithValue("USERNAMEHASHED", linkValidation.UsernameHashed);
                cmd.Parameters.AddWithValue("IDENTIFIERHASHED", linkValidation.IdentifierHashed);


                dbMethods.OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string usernameHashed = reader.GetString("usernameHashed");
                        string identifierHashed = reader.GetString("identifierHashed");
                        Enum.TryParse(reader.GetString("status"), out LinkStatus status);

                        return new AppointmentLink(id, usernameHashed, identifierHashed, status);
                    }
                }

                return null;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new DALException("Couldn't get appointment link", ex);
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }

        public void saveLinkHashes(AppointmentLink appointemntLink)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `appointments_links` " +
                    "(`usernameHashed`, `identifierHashed`,`status`) " +
                    "VALUES (@USERNAMEHASHED,@IDENTIFIERHASHED,@STATUS)"
                     , dbMethods.conn);

                cmd.Parameters.AddWithValue("USERNAMEHASHED", appointemntLink.UsernameHashed);
                cmd.Parameters.AddWithValue("IDENTIFIERHASHED", appointemntLink.IdentifierHashed);
                cmd.Parameters.AddWithValue("STATUS", appointemntLink.LinkStatus.ToString());

                dbMethods.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new DALException("Couldn't inseart appointment link", ex);
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }
    
        public Appointment GetSpecificAppointment(int appointment)
        {
            Appointment desiredAppointment = new Appointment();
            MySqlCommand cmd = new MySqlCommand("SELECT a.* FROM `appointment` AS a WHERE a.id = @APPOINTMENT", dbMethods.conn);
            cmd.Parameters.AddWithValue ("@APPOINTMENT", appointment);
            try
            {
                dbMethods.OpenConnection();
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            while (reader.Read())
            {
                desiredAppointment.Id = Convert.ToInt32(reader["id"]);
                desiredAppointment.RecruiterId = Convert.ToInt32(reader["recruiter_id"]);
                desiredAppointment.ApplicationId = Convert.ToInt32(reader["application_id"]);
                desiredAppointment.StartDate = Convert.ToDateTime(reader["start_date"]);
                desiredAppointment.EndDate = Convert.ToDateTime(reader["end_date"]);
                desiredAppointment.Subject = Convert.ToString(reader["subject"]);
                desiredAppointment.Body = Convert.ToString(reader["body"]);
                desiredAppointment.Location = Convert.ToString(reader["location"]);
            }
            dbMethods.CloseConnection();
            return desiredAppointment;
        }

        public Appointment UpdateSpecificAppointment(Appointment specificAppointment)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `appointment` as a SET a.`recruiter_id`= @RECRUITER WHERE a.id = @APPOINTMENT", dbMethods.conn);
            dbMethods.OpenConnection ();
            cmd.Parameters.AddWithValue("@RECRUITER", specificAppointment.RecruiterId);
            cmd.Parameters.AddWithValue("@APPOINTMENT", specificAppointment.Id);

            int result = cmd.ExecuteNonQuery();
            //if(result > 0)
            dbMethods.CloseConnection();

            return GetSpecificAppointment(specificAppointment.Id);
        }

        public bool DeleteSpecificAppointment(Appointment specificAppointment)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE a.* FROM `appointment` as a WHERE a.id = @APPOINTMENT", dbMethods.conn);
            dbMethods.OpenConnection();
            cmd.Parameters.AddWithValue("@APPOINTMENT", specificAppointment.Id);
            int result = cmd.ExecuteNonQuery();
            dbMethods.CloseConnection();
            if (result > 0)
            {              
               return true;
                
            }
            else
            {
                return false;
            }

        }
    }
}
