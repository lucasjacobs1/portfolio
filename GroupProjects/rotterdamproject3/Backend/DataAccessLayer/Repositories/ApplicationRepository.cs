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
    public class ApplicationRepository : IApplicationRepository
    {
        private MySqlDataReader reader;
        public DbMethods dbMethods { get; }
        private IUserRepository userRepository { get; }
        private IVacancyRepository vacancyRepository { get; }
        public ApplicationRepository()
        {
            this.dbMethods = new DbMethods();
            userRepository = new UserRepository();
            vacancyRepository = new VacancyRepository();
        }

        public Application GetSpecificApplication(int application)
        {
            Application desiredApplication = new Application();
            MySqlCommand cmd = new MySqlCommand("SELECT a.* FROM `applications` AS a WHERE a.id = @APPLICATION", dbMethods.conn);
            cmd.Parameters.AddWithValue("@APPLICATION", application);
            dbMethods.OpenConnection();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User candidate = userRepository.GetSpecificCandidate(Convert.ToInt32(reader["candidate_id"]));
                desiredApplication.Id = Convert.ToInt32(reader["id"]);
                desiredApplication.Candidate = candidate;
                desiredApplication.JobVacancy = null; //assign vacancy
            }
            dbMethods.CloseConnection();
            return desiredApplication;
        }

        public List<Application> GetApplicationssByVacancy(int vacancy)
        {
            List<Application> desiredApplications = new List<Application>();
            try
            {
                Application desiredApplication;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM applications WHERE vacancy_id = @VACANCY", dbMethods.conn);
                cmd.Parameters.AddWithValue("@VACANCY", vacancy);
                dbMethods.OpenConnection();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    desiredApplication = new Application();
                    User candidate = userRepository.GetSpecificCandidate(Convert.ToInt32(reader["candidate_id"]));
                    Vacancy desiredvacancy = vacancyRepository.GetSpecificVacancy(vacancy);
                    desiredApplication.Id = Convert.ToInt32(reader["id"]);
                    desiredApplication.Candidate = candidate;
                    desiredApplication.JobVacancy = desiredvacancy;
                    desiredApplications.Add(desiredApplication);
    }
                
                return desiredApplications;
}
            catch (Exception ex)
            { 
               return desiredApplications;
            }

            finally
            {
                dbMethods.CloseConnection();
            }

        }

        public void InsertApplication(Application application)
        {
            try
            {
                string sql = "INSERT INTO applications(vacancy_id, candidate_id) VALUES(@vacancy_id, @candidate_id);";
                MySqlCommand cmd = new MySqlCommand(sql, dbMethods.conn);
                cmd.Parameters.AddWithValue("vacancy_id", application.JobVacancy.Id);
                cmd.Parameters.AddWithValue("candidate_id", application.Candidate.Id);

                dbMethods.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
               
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }

    }
}

