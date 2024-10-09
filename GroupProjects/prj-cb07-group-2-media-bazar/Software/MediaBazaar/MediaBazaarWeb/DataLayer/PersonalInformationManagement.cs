using Group_Project_Website;
using Group_Project_Website.data;
using MediaBazaarWeb.LogicLayer;
using MySql.Data.MySqlClient;

namespace MediaBazaarWeb.DataLayer
{
    public class PersonalInformationManagement: BaseDAL
    {
        public void UpdateAccountInformation(int id, string email, string street, string city, string postalcode, string housenumber, int phonenumber)
        {
            try
            {
                string sql = $"UPDATE employee SET street = @street, city = @city, postalcode = @postalcode, housenumber = @housenumber, email = @email, phone = @phone WHERE id = '{id}';";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@postalcode", postalcode);
                cmd.Parameters.AddWithValue("@housenumber", housenumber);
                cmd.Parameters.AddWithValue("@phone", phonenumber);
                int n = ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {throw;}
        }

        public Employee GetPotentialUpdateInformationEmpByID(int id)
        {
            try
            {
                string sql = $"SELECT * FROM requestupdateempolyee WHERE employee_id = '{id}';";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                Employee emp;
                dr = OpenExecuteReader(cmd);
                if (dr.Read())
                {
                    
                    emp = new Employee(Convert.ToInt32(dr["id"]), dr["email"].ToString(), dr["street"].ToString(), dr["city"].ToString(), dr["postalcode"].ToString(), dr["housenumber"].ToString(), Convert.ToInt32(dr["phone"]));
                    CloseExecuteReader(dr);
                    return emp;
                }
                else
                {
                    CloseExecuteReader(dr);
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Employee GetUpdatedInformationById(int id)
        {
            try
            {
                string sql = $"SELECT * FROM requestupdateempolyee WHERE Employee_Id = '{id}';  ";
                MySqlCommand sqlCommand = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                Employee emp;
                dr = OpenExecuteReader(sqlCommand);
                if (dr.Read())
                {
                    emp = new Employee(Convert.ToInt32(dr["employee_Id"]), dr["email"].ToString(), dr["street"].ToString(), dr["city"].ToString(), dr["postalcode"].ToString(), dr["housenumber"].ToString(), Convert.ToInt32(dr["phone"]));
                    CloseExecuteReader(dr);
                    return emp;
                }
                else
                {
                    CloseExecuteReader(dr);
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
        //need to make these tables in database
        public bool CheckRequestUpdateExist(int id)
        {
            try
            {
                string sql = $"SELECT Employee_Id FROM requestupdateempolyee WHERE Employee_Id = '{id}';  ";
                MySqlCommand sqlCommand = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);
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

        public bool AddRequestUpdateInformationEmp(Employee employee)
        {
            try
            {
                string sql = "INSERT INTO requestupdateempolyee (employee_id,email,street, city, postalcode, housenumber,phone ) VALUES (@Id, @Email, @Street, @City, @Postalcode, @Housenumber, @PhoneNumber); ";
                MySqlCommand sqlCommand = new MySqlCommand(sql, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@Id", employee.ID);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@Street", employee.Street);
                sqlCommand.Parameters.AddWithValue("@City", employee.City);
                sqlCommand.Parameters.AddWithValue("@Postalcode", employee.PostalCode);
                sqlCommand.Parameters.AddWithValue("@Housenumber", employee.HouseNumber);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.Phonenumber);

                int n = ExecuteNonQuery(sqlCommand);

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        //still do this
        public bool UpdateRequestUpdateInformationEmp(Employee employee)
        {
            try
            {
                string sql = $"UPDATE requestupdateempolyee SET email = '{employee.Email}', street = '{employee.Street}', city = '{employee.City}', postalcode = '{employee.PostalCode}', housenumber = '{employee.HouseNumber}', phone = '{employee.Phonenumber}';";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                int n = ExecuteNonQuery(cmd);
                if (n >= 1) { return true; } else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeleteRequestUpdateInformationEmp(int id)
        {
            string sql = "DELETE FROM requestupdateempolyee WHERE employee_id = @Id;";
            MySqlCommand cmd = new MySqlCommand(sql,GetDBConnection());
            cmd.Parameters.AddWithValue("Id", id);
            try
            {
                int n = ExecuteNonQuery(cmd);
                if(n >= 1)
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

        public bool UpdateContactPerson(ContactPerson contactPesron)
        {
            try
            {
                string sql = $"UPDATE contact_person SET email = '{contactPesron.Email}', name = '{contactPesron.Name}', phone = '{contactPesron.Phone}';";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                int n = ExecuteNonQuery(cmd);
                if (n >= 1) { return true; } else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
