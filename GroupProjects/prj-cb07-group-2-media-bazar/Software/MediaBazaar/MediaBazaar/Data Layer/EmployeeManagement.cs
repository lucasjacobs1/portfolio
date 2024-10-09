using System;
using System.Collections.Generic;
using MediaBazaar.Data_Layer;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace MediaBazaar
{
    public class EmployeeManagement:BaseDAL
    {
        private string username;
        private string password;

        public bool AddEmployee(Employee employee, string password)
        {
            try
            {
                //Prepare query
                String sqlStatement = "INSERT INTO unapproved_employee (firstname, lastname,email,password,address,salary,bsn,phone,role) VALUES (@Firstname, @Lastname, @Email, @Password, @Street, @City,@Postalcode, @Housenumber, @Salary, @BSN, @PhoneNumber, @Role)";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@Firstname", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@Lastname", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.Parameters.AddWithValue("@Street", employee.Street);
                sqlCommand.Parameters.AddWithValue("@City", employee.City);
                sqlCommand.Parameters.AddWithValue("@Postalcode", employee.PostalCode);
                sqlCommand.Parameters.AddWithValue("@Housenumber", employee.HouseNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@BSN", employee.Bsn);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Role", employee.Role);
                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);

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

        public void DeleteEmployee(int id)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM employee WHERE id = @EmpId", GetDBConnection());
            cmd.Parameters.Add("@EmpId", MySqlDbType.Int32).Value = id;
            try
            {
                ExecuteNonQuery(cmd);
                //MessageBox.Show("Employee is deleted. \n" + ex.Message, "Information", MessageBoxButtons.OK, MessageBox.Information)

            }
            catch (MySqlException ex)
            {

                //MessageBox.Show("Employee is not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBox.Information)
            }
        }
        //Example of displaying and searching the employee info 
        public void DisplayAndSearchForEmployee(string sql, string whereWeDisplay)
        {
            GetDBConnection().Open();
            string query = sql;
            MySqlCommand mySqlCommand = new MySqlCommand(query, GetDBConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            //someting else
            GetDBConnection().Close();
        }
        public Employee GetEmployeeByEmail(string email)
        {
            try
            {
                String sqlStatement = $"SELECT * FROM employee where email = '{email}';";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("@email", username);

                MySqlDataReader dr;
                Employee emp;
                dr = OpenExecuteReader(sqlCommand);

                if (dr.Read())
                {
                    emp = new Employee(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["street"].ToString(), dr["city"].ToString(), dr["postalcode"].ToString(), dr["housenumber"].ToString(), dr["email"].ToString(), Convert.ToDouble(dr["salary"]), Convert.ToInt32(dr["bsn"]), Convert.ToInt32(dr["phone"]), Convert.ToInt32(dr["role"]), Convert.ToDouble(dr["fte"]));
                    CloseExecuteReader(dr);
                    return emp;
                }
                else { CloseExecuteReader(dr); return null; }


            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
        }
        public List<Employee> GetAllManagers()
        {
            List<Employee> employees = new List<Employee>(); ;
            try
            {
                String sqlStatement = "SELECT * FROM employee WHERE role IN (0,1,2);";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    Employee e = new Employee(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["email"].ToString(), dr["street"].ToString(), dr["city"].ToString(), dr["postalcode"].ToString(), dr["housenumber"].ToString(), Convert.ToDouble(dr["salary"]), Convert.ToInt32(dr["bsn"]), Convert.ToInt32(dr["phone"]), Convert.ToInt32(dr["role"]), Convert.ToDouble(dr["fte"]));
                    employees.Add(e);
                }
                CloseExecuteReader(dr);
                return employees;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>(); ;
            try
            {
                String sqlStatement = "SELECT * FROM employee;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    Employee e = new Employee(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["street"].ToString(), dr["city"].ToString(), dr["postalcode"].ToString(), dr["housenumber"].ToString(), dr["email"].ToString(), Convert.ToDouble(dr["salary"]), Convert.ToInt32(dr["bsn"]), Convert.ToInt32(dr["phone"]), Convert.ToInt32(dr["role"]), Convert.ToDouble(dr["fte"]));
                    employees.Add(e);
                }
                CloseExecuteReader(dr);
                return employees;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
        }
        public List<Employee> GetWaitingEmployees()
        {
            List<Employee> employees = new List<Employee>(); ;
            try
            {
                String sqlStatement = "SELECT * FROM unapproved_employee;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    Employee e = new Employee(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["email"].ToString(), dr["street"].ToString(), dr["city"].ToString(), dr["postalcode"].ToString(), dr["housenumber"].ToString(), Convert.ToDouble(dr["salary"]), Convert.ToInt32(dr["bsn"]), Convert.ToInt32(dr["phone"]), Convert.ToInt32(dr["role"]), Convert.ToDouble(dr["fte"]));
                    employees.Add(e);
                }
                CloseExecuteReader(dr);
                return employees;
            }
            catch (MySqlException ex)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
        }
        public bool ApproveEmployee(int id)
        {
            try
            {
                //Prepare query
                String sqlStatement = "INSERT INTO employee (employee.name,employee.email,employee.password,employee.address,employee.salary,employee.bsn,employee.phone,employee.role) SELECT unapproved_employee.name,unapproved_employee.email,unapproved_employee.password,unapproved_employee.address,unapproved_employee.salary,unapproved_employee.bsn,unapproved_employee.phone,unapproved_employee.role FROM unapproved_employee WHERE id = @id;DELETE FROM unapproved_employee WHERE id = @id; ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@id", id);

                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);

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
        public bool RejectEmployee(int id)
        {
            try
            {
                //Prepare query
                String sqlStatement = "DELETE FROM unapproved_employee WHERE id = @id; ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@id", id);

                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);

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
        //EmployeeForm employeeForm;
        //private EmployeeManagement hr;

        //public void Display()
        //{
        //    hr.DisplayAndSearchGame("SELECT ID, Name, Price, Type, Description FROM gametable", dataGridView);
        //}
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    hr.DisplayAndSearchGame("SELECT ID, Name, Price, Type, Description FROM gametable WHERE id =" + tbSearch.Text + " AND Name LIKE'%" + tbSearchName.Text + "%'", dataGridView);

        //}
    }
}
