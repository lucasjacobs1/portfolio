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
    public class MatchManagement: BaseDAL, IMatchService
    {
        public void AddMatchToTournament(TournamentMatch tournamentMatch)
        {
            try
            {
                string sql = "INSERT INTO tournament_match (tournament_id, playerHome_id, playerAway_id) VALUES (@tournamentId, @playerHomeId, @playerAwayId);";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@tournamentId", tournamentMatch.TournamentId);
                cmd.Parameters.AddWithValue("@playerHomeId", tournamentMatch.PlayerHomeId);
                cmd.Parameters.AddWithValue("@playerAwayId", tournamentMatch.PlayerAwayId);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }

        public List<TournamentMatch> GetAllMatchesOfATournament(int tournamentId)
        {
            try
            {
                List<TournamentMatch> matches = new List<TournamentMatch>();
                string sql = "SELECT * FROM tournament_match WHERE tournament_id = @tournamentId;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    matches.Add(new TournamentMatch(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["tournament_id"]), Convert.ToInt32(dr["playerHome_id"]), Convert.ToInt32(dr["playerAway_id"])));
                }
                CloseExecuteReader(dr);
                return matches;
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
            finally { CloseConnection(); }
        }

        public void AddMatchResult(MatchResult matchResult)
        {
            try
            {
                string sql = "INSERT INTO match_result (match_id, playerHome_score, playerAway_score) VALUES (@matchId, @playerHomeScore, @playerAwayScore);";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@matchId", matchResult.MatchId);
                cmd.Parameters.AddWithValue("@playerHomeScore", matchResult.PlayerHomeScore);
                cmd.Parameters.AddWithValue("@playerAwayScore", matchResult.PlayerAwayScore);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw new DatabaseFailedException("The databaseconnection is not working at the moment-- Sorry for the inconvenience");
            }
        }
        //USING of a left join
        public List<TournamentMatch> GetUnRegisteredMatchesOfTournament(int tournamentId)
        {
            try
            {
                List<TournamentMatch> matches = new List<TournamentMatch>();
                string sql = "select t.id, t.tournament_id, t.playerHome_id, t.playerAway_id FROM tournament_match as t LEFT JOIN match_result as m ON t.id = m.match_id WHERE m.match_id IS NULL AND tournament_id = @tournamentId;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    matches.Add(new TournamentMatch(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["tournament_id"]), Convert.ToInt32(dr["playerHome_id"]), Convert.ToInt32(dr["playerAway_id"])));
                }
                CloseExecuteReader(dr);
                return matches;
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
        //USING of a JOIN
        public List<TournamentMatch> GetRegisteredMatchesOfTournament(int tournamentId)
        {
            try
            {
                List<TournamentMatch> matches = new List<TournamentMatch>();
                string sql = "select t.id, t.tournament_id, t.playerHome_id, t.playerAway_id, m.playerHome_score, m.playerAway_score FROM tournament_match as t JOIN match_result as m ON t.id = m.match_id WHERE tournament_id = @tournamentId;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                MySqlDataReader dr;
                dr = OpenExecuteReader(cmd);
                while (dr.Read())
                {
                    matches.Add(new TournamentMatch(dr.GetInt32("id"), Convert.ToInt32(dr["tournament_id"]), Convert.ToInt32(dr["playerHome_id"]), Convert.ToInt32(dr["playerAway_id"]), new MatchResult(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["playerHome_score"]), Convert.ToInt32(dr["playerAway_score"]))));
                }
                CloseExecuteReader(dr);
                return matches;
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