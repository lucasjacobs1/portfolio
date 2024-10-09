using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBazaar.Data_Layer
{
    public class ComplainManagement : BaseDAL
    {
        public bool DeleteRequestUpdateInformationEmp(int id)
        {
            string sql = $"DELETE FROM requestupdateempolyee WHERE id = {id};";
            MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
            try
            {
                int n = ExecuteNonQuery(cmd);
                if (n >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Complaint> GetComplaints()
        {
            List<Complaint> complaints = new List<Complaint>(); 
            try
            {
                String sqlStatement = "select requestupdateempolyee.id, requestupdateempolyee.employee_id, s.first_name as complainerID,requestupdateempolyee.email,requestupdateempolyee.street,requestupdateempolyee.city,requestupdateempolyee.postalcode,requestupdateempolyee.housenumber,requestupdateempolyee.phone from requestupdateempolyee inner join employee s on requestupdateempolyee.employee_id = s.id inner join employee d on requestupdateempolyee.employee_id = d.id;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    Complaint c = new Complaint(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["employee_id"]), dr["complainerID"].ToString(), dr["email"].ToString(), dr["street"].ToString(),dr["city"].ToString(), Convert.ToInt32(dr["phone"]), dr["postalcode"].ToString(), Convert.ToInt32(dr["housenumber"]));
                    complaints.Add(c);
                }
                CloseExecuteReader(dr);
                return complaints;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
        }
        public bool SolveAndArchieveComplaint(int complaintID, int empId, string email, string street, string city, string postalcode, string housenumber, int phonenumber)
        {
            ///////
            try
            {
                string sql = $"UPDATE employee SET street = @street, city = @city, postalcode = @postalcode, housenumber = @housenumber, email = @email, phone = @phone WHERE id = {empId};";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@postalcode", postalcode);
                cmd.Parameters.AddWithValue("@housenumber", housenumber);
                cmd.Parameters.AddWithValue("@phone", phonenumber);
                int n = ExecuteNonQuery(cmd);
                return true;
            }

            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                                        "--This should not be happening--\n" +
                                        "Unexpected result from database manager:\n" +
                                        "addition of user entry results in number ");
            }

        }
    }
}
