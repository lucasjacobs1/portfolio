using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Group_Project_Website.data
{
    public class UserDAL : BaseDAL
    {
        public bool EditEmployeeWithPassword(Employee employee, string newPassword)
        {
            ///////
            try
            {
                String sqlStatement = $"UPDATE employee SET fistname = '{employee.FirstName}', lastname = '{employee.LastName}', email = '{employee.Email}', street = '{employee.Street}', city = '{employee.City}', postalcode = '{employee.PostalCode}', housenumber = '{employee.HouseNumber}', salary = {employee.Salary}, bsn = {employee.Bsn}, phone = {employee.Phonenumber}, role = {employee.Role} WHERE id = {employee.ID};";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@firstname", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@Password", newPassword);
                sqlCommand.Parameters.AddWithValue("@street", employee.Street);
                sqlCommand.Parameters.AddWithValue("@city", employee.City);
                sqlCommand.Parameters.AddWithValue("@postalcode", employee.PostalCode);
                sqlCommand.Parameters.AddWithValue("@housenumber", employee.HouseNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@Bsn", employee.Bsn);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Role", employee.Role);
                sqlCommand.Parameters.AddWithValue("@EmpId", employee.ID);
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
        public bool EditEmployeeWithoutPassword(Employee employee)
        {
            try
            {
                String sqlStatement = $"UPDATE employee SET fistname = '{employee.FirstName}', lastname = '{employee.LastName}', email = '{employee.Email}', street = '{employee.Street}', city = '{employee.City}', postalcode = '{employee.PostalCode}', housenumber = '{employee.HouseNumber}', salary = {employee.Salary}, bsn = {employee.Bsn}, phone = {employee.Phonenumber}, role = {employee.Role} WHERE id = {employee.ID};";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@firstname", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@lastname", employee.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@street", employee.Street);
                sqlCommand.Parameters.AddWithValue("@city", employee.City);
                sqlCommand.Parameters.AddWithValue("@postalcode", employee.PostalCode);
                sqlCommand.Parameters.AddWithValue("@housenumber", employee.HouseNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@Bsn", employee.Bsn);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Role", employee.Role);
                sqlCommand.Parameters.AddWithValue("@EmpId", employee.ID);

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

        public bool ValidateLogin(string email, string password)
        {
            try
            {
                String sqlStatement = "SELECT * FROM employee WHERE  email = @email AND password = @password; ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);
                MySqlDataReader dr;
                dr = OpenExecuteReader(sqlCommand);
                if (dr.Read())
                {
                    CloseExecuteReader(dr);
                    return true;

                }
                else { CloseExecuteReader(dr); return false; }
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
