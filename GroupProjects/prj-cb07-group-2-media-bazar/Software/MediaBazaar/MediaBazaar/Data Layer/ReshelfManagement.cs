using MediaBazaar.Logic_Layer;
using MediaBazaar.Data_Layer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Data_Layer
{
    public class ReshelfManagement : BaseDAL
    {
        ProductManagement productmanager = new ProductManagement();

        public bool AddPendingRequest(ReShelfRequest request)
        {
            try
            {
                //Prepare query
                String sqlStatement = "INSERT INTO reshelfrequest (productid, message, sender, datesent) VALUES (@productid, @message, @sender, @datesent)";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@productid", productmanager.GetProductIdByName(request.Product.Name));
                sqlCommand.Parameters.AddWithValue("@message", request.Message);
                sqlCommand.Parameters.AddWithValue("@sender", request.Sender);
                sqlCommand.Parameters.AddWithValue("@datesent", request.DateSent);
                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);

                return true;
            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                   "--This should not be happening--\n" +
                   "Unexpected result from database manager:\n" +
                   "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }

        public bool AddAcceptedRequest(ReShelfRequest request)
        {
            try
            {
                String sqlStatement = "INSERT INTO acceptedreshelfrequest (productid, message, sender, datesent) VALUES (@productid, @message, @sender, @datesent)";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@productid", productmanager.GetProductIdByName(request.Product.Name));
                sqlCommand.Parameters.AddWithValue("@message", request.Message);
                sqlCommand.Parameters.AddWithValue("@sender", request.Sender);
                sqlCommand.Parameters.AddWithValue("@datesent", request.DateSent);
                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);
                return true;
            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                   "--This should not be happening--\n" +
                   "Unexpected result from database manager:\n" +
                   "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }

        public bool AddRejectedRequest(ReShelfRequest request, string reason)
        {
            try
            {
                String sqlStatement = "INSERT INTO rejectedreshelfrequest (productid, message, reason, sender, datesent) VALUES (@productid, @message, @reason, @sender, @datesent)";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@productid", productmanager.GetProductIdByName(request.Product.Name));
                sqlCommand.Parameters.AddWithValue("@message", request.Message);
                sqlCommand.Parameters.AddWithValue("@reason", reason);
                sqlCommand.Parameters.AddWithValue("@sender", request.Sender);
                sqlCommand.Parameters.AddWithValue("@datesent", request.DateSent);
                //Depending on n, we can determine what will be returned
                int n = ExecuteNonQuery(sqlCommand);
                return true;
            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                   "--This should not be happening--\n" +
                   "Unexpected result from database manager:\n" +
                   "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }

        public void DeletePendingRequestByProduct(Product product)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM reshelfreqeust WHERE productid = @productid", GetDBConnection());
            cmd.Parameters.AddWithValue("@productid", productmanager.GetProductIdByName(product.Name));
            try
            {
                ExecuteNonQuery(cmd);
                //MessageBox.Show("product is deleted. \n" + ex.Message, "Information", MessageBoxButtons.OK, MessageBox.Information)

            }
            catch (MySqlException ex)
            {

                //MessageBox.Show("product is not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBox.Information)
            }
        }        

        public ReShelfRequest GetPendingRequestByProduct(Product product)
        {
            try
            {
                String sqlStatement = $"SELECT * FROM reshelfrequest WHERE productid = @productid;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("@productid", productmanager.GetProductIdByName(product.Name));

                MySqlDataReader dr;
                ReShelfRequest req;
                dr = OpenExecuteReader(sqlCommand);

                if (dr.Read())
                {
                    req = new ReShelfRequest(product, dr["message"].ToString(), dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]));
                    CloseExecuteReader(dr);
                    return req;
                }
                else { CloseExecuteReader(dr); return null; }


            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
        }

        public int? GetPendingRequestIdByProduct(Product product)
        {
            try
            {
                string sql = "SELECT id FROM reshelfrequest WHERE productid = @productid";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@productid", productmanager.GetProductIdByName(product.Name));

                MySqlDataReader dr = OpenExecuteReader(cmd);

                if (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    CloseExecuteReader(dr);
                    return id;
                }
                else
                {
                    CloseExecuteReader(dr);
                    return null;
                }
            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }

        public List<ReShelfRequest> GetAllPendingRequests()
        {
            List<ReShelfRequest> requests = new List<ReShelfRequest>();
            try
            {
                String sqlStatement = $"SELECT * FROM reshelfrequest ;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    if (dr["message"] != null)
                    {
                        ReShelfRequest req1 = new ReShelfRequest(productmanager.GetProductByID(Convert.ToInt32(dr["productid"])), dr["message"].ToString(), dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]));
                        requests.Add(req1);
                    }
                    else if (dr["message"] == null)
                    {
                        ReShelfRequest req2 = new ReShelfRequest(productmanager.GetProductByID(Convert.ToInt32(dr["productid"])), "No message was added!", dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]));
                        requests.Add(req2);
                    }
                    else
                    {
                        return null;
                    }
                }
                CloseExecuteReader(dr);
                return requests;


            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }

        public List<ReShelfRequest> GetAllAcceptedRequests()
        {
            List<ReShelfRequest> requests = new List<ReShelfRequest>();
            try
            {
                String sqlStatement = $"SELECT * FROM acceptedreshelfrequest ;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    if (dr["message"] != null)
                    {
                        ReShelfRequest req1 = new ReShelfRequest(productmanager.GetProductByID(Convert.ToInt32(dr["productid"])), dr["message"].ToString(), dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]).Date);
                        requests.Add(req1);
                    }
                    else if (dr["message"] == null)
                    {
                        ReShelfRequest req2 = new ReShelfRequest(productmanager.GetProductByID(Convert.ToInt32(dr["productid"])), "No message was added!", dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]).Date);
                        requests.Add(req2);
                    }
                    else
                    {
                        return null;
                    }
                }
                CloseExecuteReader(dr);
                return requests;


            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }

        public List<ReShelfRequest> GetAllRejectedRequests()
        {
            List<ReShelfRequest> requests = new List<ReShelfRequest>();
            try
            {
                String sqlStatement = $"SELECT * FROM rejectedreshelfrequest ;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                MySqlDataReader dr;

                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    if (dr["message"] != null)
                    {
                        ReShelfRequest req1 = new ReShelfRequest(productmanager.GetProductByID(Convert.ToInt32(dr["productid"])), dr["message"].ToString(), dr["reason"].ToString(), dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]));
                        requests.Add(req1);
                    }
                    else if (dr["message"] == null)
                    {
                        ReShelfRequest req2 = new ReShelfRequest(productmanager.GetProductByID(Convert.ToInt32(dr["productid"])), "No message was added!", dr["reason"].ToString(), dr["sender"].ToString(), Convert.ToDateTime(dr["datesent"]));
                        requests.Add(req2);
                    }
                    else
                    {
                        return null;
                    }
                }
                CloseExecuteReader(dr);
                return requests;


            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }
            finally
            {
                GetDBConnection().Close();
            }
        }
    }
}
