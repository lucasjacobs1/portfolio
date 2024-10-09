using Group_Project_Website;
using Group_Project_Website.data;
using MediaBazaarWeb.LogicLayer;
using MySql.Data.MySqlClient;

namespace MediaBazaarWeb.DataLayer
{
    public class ContactPersonManagement: BaseDAL
    {
        public ContactPerson GetContactPersonByEmployeeId(int id)
        {
			try
			{
                string sql = $"SELECT * FROM contact_person WHERE employee_id = '{id}' ;";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                MySqlDataReader dr;
                ContactPerson CP;
                dr = OpenExecuteReader(cmd);
                if (dr.Read())
                {
                    CP = new ContactPerson(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["employee_id"]), dr["name"].ToString(), Convert.ToInt32(dr["phone"]), dr["email"].ToString());
                    CloseExecuteReader(dr);
                    return CP;
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

        /*public bool UpdateContactPersonByEmployeeId(int id)
		{
            string sql = "UPDATE "
		}*/
    }
}
