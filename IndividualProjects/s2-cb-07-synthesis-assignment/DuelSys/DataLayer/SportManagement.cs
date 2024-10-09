using LogicLayer;
using LogicLayer.CustomExceptions;
using LogicLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SportManagement: BaseDAL, ISportService
    {
        public List<Sport> GetAllSports()
        {
            try
            {
                List<Sport> sports = new List<Sport>();
                string sql = "SELECT * FROM sport;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);

                while (dr.Read())
                {
                    Sport s = new Sport(Convert.ToInt32(dr["id"]), dr["sport"].ToString());
                    sports.Add(s);
                }
                CloseExecuteReader(dr);
                return sports;
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

        public Sport GetSportById(int id)
        {
            try
            {
                string sql = "SELECT * FROM sport WHERE sport = @sportID;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@sportID", id);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                
                if (dr.Read())
                {
                    Sport sport = new Sport(dr.GetInt32("id"), dr.GetString("sport"));
                    CloseExecuteReader(dr);
                    return sport;
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
            finally { CloseConnection(); }

        }
    }
}
