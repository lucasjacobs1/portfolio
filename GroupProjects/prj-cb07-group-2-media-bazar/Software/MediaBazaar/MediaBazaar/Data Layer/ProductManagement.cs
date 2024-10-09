using System;
using System.Collections.Generic;
using MediaBazaar.Data_Layer;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MediaBazaar.Logic_Layer;

namespace MediaBazaar.Data_Layer
{
    public class ProductManagement : BaseDAL
    {
        public bool AddProduct(Product product)
        {
            try
            {
                //Prepare query
                String sqlStatement = "INSERT INTO product (name,description,price,amountinstock, amountsold, weight, height, length, width) VALUES (@Name, @Description, @Price, @Amountinstock, @Amountsold, @Weight, @Height, @Length, @Width)";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                //Bind parameters to prevent SQL-injection.
                sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                sqlCommand.Parameters.AddWithValue("@Description", product.Description);
                sqlCommand.Parameters.AddWithValue("@Price", product.PriceInEuros);
                sqlCommand.Parameters.AddWithValue("@Amountinstock", product.AmountInstock);
                sqlCommand.Parameters.AddWithValue("@Amountsold", product.AmountSold);
                sqlCommand.Parameters.AddWithValue("@Weight", product.WeightInKG);
                sqlCommand.Parameters.AddWithValue("@Height", product.HeightInCM);
                sqlCommand.Parameters.AddWithValue("@Length", product.LengthInCM);
                sqlCommand.Parameters.AddWithValue("@Width", product.WidthInCM);
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
        }
        public void DeleteProductByName(string name)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM product WHERE name = @PrdName", GetDBConnection());
            cmd.Parameters.Add("@PrdName", MySqlDbType.VarChar).Value = name;
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

        public Product GetProductByID(int id)
        {
            try
            {
                string sqlStatement = "SELECT * FROM product where id = @id;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("@id", id);

                MySqlDataReader dr;
                Product prd;
                dr = OpenExecuteReader(sqlCommand);

                if (dr.Read())
                {
                    prd = new Product(dr["name"].ToString(), dr["description"].ToString(), Convert.ToDouble(dr["price"]), Convert.ToInt32(dr["amountinstock"]), Convert.ToInt32(dr["amountsold"]), dr["barcode"].ToString(), Convert.ToInt32(dr["weight"]), Convert.ToInt32(dr["height"]), Convert.ToInt32(dr["length"]), Convert.ToInt32(dr["width"]));
                    CloseExecuteReader(dr);
                    return prd;
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
        }

        public Product GetProductByName(string name)
        {
            try
            {
                String sqlStatement = $"SELECT * FROM product WHERE name = @name;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());
                sqlCommand.Parameters.AddWithValue("@name", name);

                MySqlDataReader dr;
                Product prd;
                dr = OpenExecuteReader(sqlCommand);

                if (dr.Read())
                {
                    prd = new Product(dr["name"].ToString(), dr["description"].ToString(), Convert.ToDouble(dr["price"]), Convert.ToInt32(dr["amountinstock"]), Convert.ToInt32(dr["amountsold"]), dr["barcode"].ToString(), Convert.ToInt32(dr["weight"]), Convert.ToInt32(dr["height"]), Convert.ToInt32(dr["length"]), Convert.ToInt32(dr["width"]));
                    CloseExecuteReader(dr);
                    return prd;
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

        public int? GetProductIdByName(string name)
        {
            try
            {
                string sql = "SELECT id FROM product WHERE name = @name";
                MySqlCommand cmd = new MySqlCommand(sql, GetDBConnection());
                cmd.Parameters.AddWithValue("@name", name);

                MySqlDataReader dr = OpenExecuteReader(cmd);

                if (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    dr.Close();
                    return id;
                }
                else
                {
                    dr.Close();
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

        public bool EditProduct(Product product, string oldName)
        {
            try
            {
                String sqlStatement = $"UPDATE product (name,description,price,amountinstock, amountsold, weight, height, length, width) VALUES (@Name, @Description, @Price, @Amountinstock, @Amountsold, @Weight, @Height, @Length, @Width) WHERE id = @id;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                sqlCommand.Parameters.AddWithValue("@Description", product.Description);
                sqlCommand.Parameters.AddWithValue("@Price", product.PriceInEuros);
                sqlCommand.Parameters.AddWithValue("@Amountinstock", product.AmountInstock);
                sqlCommand.Parameters.AddWithValue("@Amountsold", product.AmountSold);
                sqlCommand.Parameters.AddWithValue("@Weight", product.WeightInKG);
                sqlCommand.Parameters.AddWithValue("@Height", product.HeightInCM);
                sqlCommand.Parameters.AddWithValue("@Length", product.LengthInCM);
                sqlCommand.Parameters.AddWithValue("@Width", product.WidthInCM);
                sqlCommand.Parameters.AddWithValue("@id", product.Id);
                
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
        public bool SellItem(Product product,int ammountToSell)
        {
            try
            {
                String sqlStatement = $"UPDATE product SET amountinstock = {product.AmountInstock-ammountToSell}, amountsold = {product.AmountSold+ammountToSell} WHERE name = '{product.Name}';";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

               

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
        public bool EditProduct(Product product, string oldName, int ammount)
        {
            try
            {
                String sqlStatement = $"UPDATE product SET name = @Name, description = @Description, price = @Price, amountinstock = @Amountinstock, amountsold = @Amountsold, weight = @Weight, height = @Height, length = @Length, width = @Width WHERE id = @Id;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                sqlCommand.Parameters.AddWithValue("@Description", product.Description);
                sqlCommand.Parameters.AddWithValue("@Price", product.PriceInEuros);
                sqlCommand.Parameters.AddWithValue("@Amountinstock", product.AmountInstock);
                sqlCommand.Parameters.AddWithValue("@Amountsold", product.AmountSold);
                sqlCommand.Parameters.AddWithValue("@Weight", product.WeightInKG);
                sqlCommand.Parameters.AddWithValue("@Height", product.HeightInCM);
                sqlCommand.Parameters.AddWithValue("@Length", product.LengthInCM);
                sqlCommand.Parameters.AddWithValue("@Width", product.WidthInCM);
                sqlCommand.Parameters.AddWithValue("@Id", product.Id);

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
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                String sqlStatement = $"SELECT * FROM product ;";
                MySqlCommand sqlCommand = new MySqlCommand(sqlStatement, GetDBConnection());

                MySqlDataReader dr;
                
                dr = OpenExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    Product prd = new Product(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["description"].ToString(), Convert.ToDouble(dr["price"]), Convert.ToInt32(dr["amountinstock"]), Convert.ToInt32(dr["amountsold"]), dr["barcode"].ToString(), Convert.ToInt32(dr["weight"]), Convert.ToInt32(dr["height"]), Convert.ToInt32(dr["length"]), Convert.ToInt32(dr["width"]));
                    products.Add(prd);
                    
                }
                CloseExecuteReader(dr);
                return products;


            }
            catch (MySqlException)
            {
                throw new ArgumentOutOfRangeException(
                  "--This should not be happening--\n" +
                  "Unexpected result from database manager:\n" +
                  "addition of user entry results in number ");
            }

        }
    }
}
