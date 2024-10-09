using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediaBazaar.Data_Layer
{
    public class ScheduleManager : BaseDAL
    {
        public void AddSchedule(string name, string date, string shiftType)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO schedule (EmployeeName,shiftDate,shiftType)values(?,?,?)", GetDBConnection());
            cmd.Parameters.AddWithValue("EmployeeName", name);
            cmd.Parameters.AddWithValue("shiftDate", date);
            cmd.Parameters.AddWithValue("shiftType", shiftType);
            try
            {
                ExecuteNonQuery(cmd);
            }
            catch (MySqlException e)
            {

                //MessageBox.Show("Schedule not added \n" + e.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public List<string> GetEmployees()
        {
            List<string> employees = new List<string>();
            try
            {
                String sqlStatement = "SELECT * FROM employee;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string name = dr["first_name"].ToString();
                    employees.Add(name);
                }
                CloseExecuteReader(dr);
                return employees;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public List<string> GetDeps()
        {
            List<string> deps = new List<string>();
            try
            {
                String sqlStatement = "SELECT * FROM roles;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string dep = dr["name"].ToString();
                    deps.Add(dep);
                }
                CloseExecuteReader(dr);
                return deps;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public string Event(string year, string mounth, string day)
        {
            try
            {
                String sqlStatement = "SELECT * FROM schedule where shiftDate = ?";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                if (dr.Read())
                {
                    string name = dr["EmployeeName"].ToString();
                    GetDBConnection().Close();
                    return name;
                }

                CloseExecuteReader(dr);
                return null;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public string EventByID(string name1,string year, string mounth, string day)
        {
            try
            {
                String sqlStatement = $"SELECT * FROM schedule where shiftDate = ? AND EmployeeName = '{name1}'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string name = dr["EmployeeName"].ToString();
                    GetDBConnection().Close();
                    return name;
                }
                CloseExecuteReader(dr);
                return null;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public string ScheduleByID(string id, string year, string mounth, string day,string type)
        {
            try
            {
                String sqlStatement = $"SELECT * FROM schedule where shiftDate = ? AND id = '{id}' AND shiftType = '{type}'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string name = dr["EmployeeName"].ToString();
                    GetDBConnection().Close();
                    return name;
                }
                CloseExecuteReader(dr);
                return null;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public string EventByTime(string year, string mounth, string day)
        {
            try
            {
                String sqlStatement = $"SELECT shiftType FROM schedule where shiftDate = ?";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string shiftType = dr["shiftType"].ToString();
                    GetDBConnection().Close();
                    return shiftType;
                }

                CloseExecuteReader(dr);
                return null;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
        }
        public List<string> Shifts(string year, string mounth, string day)
        {
            List<string> list = new List<string>();
            try
            {
                String sqlStatement = "SELECT schedule.id,EmployeeName,roles.name,shiftType FROM schedule JOIN employee on schedule.EmployeeName = employee.first_name join roles on employee.role = roles.id WHERE schedule.shiftDate = ?";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string id = dr["id"].ToString();
                    string name = dr["EmployeeName"].ToString();
                    string type = dr["shiftType"].ToString();
                    string dep = dr["name"].ToString();
                    list.Add($"~{id}~ {name} ({dep})-{type}");
                }
                CloseExecuteReader(dr);
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public List<string> ShiftsByName(string Name,string year, string mounth, string day)
        {
            List<string> list = new List<string>();
            try
            {
                String sqlStatement = $"SELECT EmployeeName,roles.name,shiftType FROM schedule JOIN employee on schedule.EmployeeName = employee.first_name join roles on employee.role = roles.id WHERE schedule.shiftDate = '@shiftDate' AND schedule.EmployeeName = '{Name}'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("@shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string name = dr["EmployeeName"].ToString();
                    string type = dr["shiftType"].ToString();
                    string dep = dr["first_name"].ToString();
                    list.Add($"{name} ({dep})-{type}");
                }
                CloseExecuteReader(dr);
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public List<string> ShiftsByTime(string shiftType, string year, string mounth, string day)
        {
            List<string> list = new List<string>();
            try
            {
                String sqlStatement = $"SELECT EmployeeName,roles.name,shiftType FROM schedule JOIN employee on schedule.EmployeeName = employee.name join roles on employee.role = roles.id WHERE schedule.shiftDate = '@shiftDate' AND schedule.shiftType = '{shiftType}'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("@shiftDate", day + "/" + mounth + "/" + year);
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    string name = dr["EmployeeName"].ToString();
                    string type = dr["shiftType"].ToString();
                    string dep = dr["first_name"].ToString();
                    list.Add($"{name} ({dep})-{type}");
                }
                CloseExecuteReader(dr);
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number " + ex.Message);
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
        public bool DeleteShift(int shiftID)
        {
           
                MySqlCommand cmd = new MySqlCommand("DELETE FROM schedule WHERE id = @id", GetDBConnection());
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = shiftID;
                try
                {
                    ExecuteNonQuery(cmd);
                return true;
                    //MessageBox.Show("product is deleted. \n" + ex.Message, "Information", MessageBoxButtons.OK, MessageBox.Information)

                }
                catch (MySqlException ex)
                {
                return false;
                    //MessageBox.Show("product is not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBox.Information)
                }
            
        }
    }

}
