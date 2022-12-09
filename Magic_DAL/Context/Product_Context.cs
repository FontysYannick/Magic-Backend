using Dapper;
using Magic_Interface.DTO;
using Magic_Interface.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Magic_DAL.Context
{
    public class Product_Context : Database, IProduct
    {
        private readonly string connectionstring;
        private readonly IDbConnection connection;


        public Product_Context(string cs)
        {
            connectionstring = cs;
            connection = new System.Data.SqlClient.SqlConnection(cs);
        }

        //GetAll
        public List<ProductDTO> Getproducts()
        {
            var sql = "SELECT * from Product";
            List<ProductDTO> list = new List<ProductDTO>();

            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    list = connection.Query<ProductDTO>(sql).ToList();
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                connection.Close();
            }

            return list;
        }
        public void Create(ProductDTO product)
        {
            var sql = "INSERT INTO Product(Name, Color, Stock) VALUES(@Name,@Color,@Stock)";
            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    connection.Query<ProductDTO>(sql, new { Name = product.Name, Color = product.Color, Stock = product.Stock });
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                connection.Close();
            }
        }
        public void Delete(int id)
        {
            var sql = "DELETE FROM Product WHERE ID = @ID";
            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    connection.Query<ProductDTO>(sql, new { ID = id });
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                connection.Close();
            }
        }
        public void Update(ProductDTO product)
        {
            var sql = "Update Product SET Name = @Name, Color = @Color, Stock = @Stock WHERE ID = '" + product.Id + "'";

            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    connection.Query<ProductDTO>(sql, new { Name = product.Name, Color = product.Color, Stock = product.Stock });
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                connection.Close();
            }
        }
        public ProductDTO GetProductById(int id)
        {
            ProductDTO prod = new ProductDTO();
            var sql = "SELECT * FROM Product WHERE ID = '" + id + "'";

            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    prod = connection.QuerySingle<ProductDTO>(sql);
                }
            }

            //catches exceptions
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //closes database connection
            finally
            {
                connection.Close();
            }

            return prod;
        }
    }
}
