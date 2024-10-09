using Group_Project_Website.data;
using MediaBazaarWeb.LogicLayer;
using MySql.Data.MySqlClient;

namespace MediaBazaarWeb.DataLayer
{
    public class AbsenceManagement: BaseDAL
    {
        public bool AddAbsence(int id, Absence absence)
        {
            try
            {
                string sql = $"INSERT INTO absence_employee (employee_id, date, reason) VALUES(@employee_id, @date, @reason)";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@employee_id", id);
                cmd.Parameters.AddWithValue("@date", absence.Date);
                cmd.Parameters.AddWithValue("@reason", absence.Reason);
                int n = ExecuteNonQuery(cmd);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
           

        }

        public bool CheckAbsenceExist(int id, Absence absence)
        {
            try
            {
                string dateTime = absence.Date.ToString("yyyy-MM-dd");
                string sql = "SELECT date, employee_id FROM absence_employee WHERE date like @date AND employee_id like @id ;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateTime;
                cmd.Parameters.AddWithValue("@id", id);
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

                return false;
            }
           
        }

        public bool AddVacation(int id, Vacation vacation)
        {
            try
            {
                int notApproved = 0;
                string sql = "INSERT INTO absence_vacation (employee_id, start_date, end_date, reason, pending) VALUES(@employee_id, @start_date, @end_date, @reason, @pending);";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@employee_id", id);
                cmd.Parameters.AddWithValue("@start_date", vacation.StartDate);
                cmd.Parameters.AddWithValue("@end_date", vacation.EndDate);
                cmd.Parameters.AddWithValue("@reason", vacation.Reason);
                cmd.Parameters.AddWithValue("@pending", notApproved);
                int n = ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
