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
    public class TournamentManagement : BaseDAL, ITournamentService
    {
        public void AddTournament(Tournament tournament)
        {
            try
            {
                string sql = "INSERT INTO tournament (description, start_date, end_date, location, min_players, max_players, sport_id, tournament_type_id) VALUES (@description, @start_date, @end_date, @location, @min_players, @max_players, @sport_id, @tournament_type_id);";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@description", tournament.Description);
                cmd.Parameters.AddWithValue("@start_date", tournament.StartDate);
                cmd.Parameters.AddWithValue("@end_date", tournament.EndDate);
                cmd.Parameters.AddWithValue("@location", tournament.Location);
                cmd.Parameters.AddWithValue("@min_players", tournament.MinimumPlayers);
                cmd.Parameters.AddWithValue("@max_players", tournament.MaximumPlayers);
                cmd.Parameters.AddWithValue("@sport_id", tournament.SportId);
                cmd.Parameters.AddWithValue("@tournament_type_id", tournament.TournamentTypeId);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }

        public void UpdateTournament(Tournament tournament)
        {
            try
            {
                string sql = "UPDATE tournament SET description = @description, start_date = @start_date, end_date = @end_date, location = @location, min_players = @min_players, max_players = @max_players, sport_id = @sport_id, tournament_type_id = @tournament_type_id where id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@id", tournament.Id);
                cmd.Parameters.AddWithValue("@description", tournament.Description);
                cmd.Parameters.AddWithValue("@start_date", tournament.StartDate);
                cmd.Parameters.AddWithValue("@end_date", tournament.EndDate);
                cmd.Parameters.AddWithValue("@location", tournament.Location);
                cmd.Parameters.AddWithValue("@min_players", tournament.MinimumPlayers);
                cmd.Parameters.AddWithValue("@max_players", tournament.MaximumPlayers);
                cmd.Parameters.AddWithValue("@sport_id", tournament.SportId);
                cmd.Parameters.AddWithValue("@tournament_type_id", tournament.TournamentTypeId);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }

        public void DeleteTournament(int id)
        {
            try
            {
                string sql = "DELETE FROM tournament WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@id", id);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }

        public List<User> GetAllUsersOfTournament(int id)
        {
            try
            {
                List<User> users = new List<User>();
                string sql = "SELECT u.id, u.first_name, u.last_name, u.email, u.password, u.role_id FROM Registration_user as r JOIN User as u ON r.user_id = u.id WHERE r.tournament_id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    User user = new User(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["email"].ToString(), dr["password"].ToString(), Convert.ToInt32(dr["role_id"]));
                    users.Add(user);
                }
                CloseExecuteReader(dr);
                return users;
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

        public List<Tournament> GetAllTournaments()
        {
            try
            {
                List<Tournament> tournaments = new List<Tournament>();
                string sql = "SELECT * FROM tournament;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    Tournament t = new Tournament(Convert.ToInt32(dr["id"]), dr["description"].ToString(), Convert.ToDateTime(dr["start_date"]).Date, Convert.ToDateTime(dr["end_date"]).Date, dr["location"].ToString(), Convert.ToInt32(dr["min_players"]), Convert.ToInt32(dr["max_players"]), Convert.ToInt32(dr["sport_id"]), Convert.ToInt32(dr["tournament_type_id"]));
                    tournaments.Add(t);
                }
                CloseExecuteReader(dr);
                return tournaments;
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

        public Tournament GetTournamentById(int id)
        {
            try
            {
                string sql = "SELECT * FROM tournament WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                if (dr.Read())
                {
                    Tournament t = new Tournament(Convert.ToInt32(dr["id"]), dr["description"].ToString(), Convert.ToDateTime(dr["start_date"]).Date, Convert.ToDateTime(dr["end_date"]).Date, dr["location"].ToString(), Convert.ToInt32(dr["min_players"]), Convert.ToInt32(dr["max_players"]), Convert.ToInt32(dr["sport_id"]), Convert.ToInt32(dr["tournament_type_id"]));
                    CloseExecuteReader(dr);
                    return t;
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

        public List<TournamentSystem> GetAllTournamentSytstems()
        {
            try
            {
                List<TournamentSystem> tournamentSystems = new List<TournamentSystem>();
                string sql = "SELECT * FROM tournament_type;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);

                while (dr.Read())
                {
                    TournamentSystem s = new TournamentSystem(Convert.ToInt32(dr["id"]), dr["name"].ToString());
                    tournamentSystems.Add(s);
                }
                CloseExecuteReader(dr);
                return tournamentSystems;
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

        public void RegisterForTournament(int tournamentId, int userId)
        {
            try
            {
                string sql = "INSERT INTO registration_user (tournament_id, user_id, registration_date) VALUES (@tournament_id, @user_id, @date);";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@tournament_id", tournamentId);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }

        public List<Tournament> GetTournamentsThatAreOpen()
        {
            try
            {
                List<Tournament> tournaments = new List<Tournament>();
                //Using the left join because we want everything is from the table tournament that is matching with table matches
                string sql = "SELECT DISTINCT t.id, t.description, t.start_date, t.end_date, t.location, t.min_players, t.max_players, t.sport_id, t.tournament_type_id FROM tournament as t LEFT JOIN tournament_match as tm ON t.id = tm.tournament_id WHERE tm.tournament_id IS NULL;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    tournaments.Add(new Tournament(Convert.ToInt32(dr["id"]), dr["description"].ToString(), Convert.ToDateTime(dr["start_date"]).Date, Convert.ToDateTime(dr["end_date"]).Date, dr["location"].ToString(), Convert.ToInt32(dr["min_players"]), Convert.ToInt32(dr["max_players"]), Convert.ToInt32(dr["sport_id"]), Convert.ToInt32(dr["tournament_type_id"])));
                }
                CloseExecuteReader(dr);
                return tournaments;
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
        public List<Tournament> GetTournamentsThatAreClosed()
        {
            try
            {
                List<Tournament> tournaments = new List<Tournament>();
                //Distinct because we dont want everything double
                string sql = "SELECT DISTINCT t.id, t.description, t.start_date, t.end_date, t.location, t.min_players, t.max_players, t.sport_id, t.tournament_type_id FROM tournament as t LEFT JOIN tournament_match as tm ON t.id = tm.tournament_id WHERE tm.tournament_id IS NOT NULL;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    tournaments.Add(new Tournament(Convert.ToInt32(dr["id"]), dr["description"].ToString(), Convert.ToDateTime(dr["start_date"]).Date, Convert.ToDateTime(dr["end_date"]).Date, dr["location"].ToString(), Convert.ToInt32(dr["min_players"]), Convert.ToInt32(dr["max_players"]), Convert.ToInt32(dr["sport_id"]), Convert.ToInt32(dr["tournament_type_id"])));
                }
                CloseExecuteReader(dr);
                return tournaments;
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