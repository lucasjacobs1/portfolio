using LogicLayer.Models;
using LogicLayer.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        public VacancyRepository()
        {
            this.dbMethods = new DbMethods();
        }

        public DbMethods dbMethods { get; }

        public List<Vacancy> GetAllVacancies()
        {
            try
            {
                Vacancy desiredvacancy;
                List<Vacancy> vacancies = new List<Vacancy>();

                MySqlCommand cmd = new MySqlCommand("SELECT `id`, `title`, `location`, `meeting_location` " +
                    "FROM `vacancy`", dbMethods.conn);

                dbMethods.OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        desiredvacancy = new Vacancy();
                        desiredvacancy.Id = reader.GetInt32("id");
                        desiredvacancy.Title = reader.GetString("title");
                        desiredvacancy.Location = reader.GetString("location");
                        desiredvacancy.MeetingLocation = reader.GetString("meeting_location");

                        vacancies.Add(desiredvacancy);
                    }
                    return vacancies;
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new DALException("Couldn't get list of all vacancies", ex);
            }
            finally
            {
                dbMethods.CloseConnection();
            }
        }

        public Vacancy GetSpecificVacancy (int vacancy)
        {
            try
            {
                Vacancy desiredvacancy = new Vacancy();
              
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vacancy WHERE id = @VACANCY", dbMethods.conn);
                cmd.Parameters.AddWithValue("@VACANCY", vacancy);

                dbMethods.OpenConnection();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        desiredvacancy.Id = reader.GetInt32("id");
                        desiredvacancy.Title = reader.GetString("title");
                        desiredvacancy.Location = reader.GetString("location");
                        desiredvacancy.MeetingLocation = reader.GetString("meeting_location");
                    }
                } return desiredvacancy;
            }
            catch(MySqlException ex)
            {
                return null;
            }
            finally
            {
                dbMethods.CloseConnection();
            }


        }
    }
}
