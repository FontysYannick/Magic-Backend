using Dapper;
using Magic_Interface.DTO;
using Magic_Interface.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_DAL.Context
{
    public class Cart_Context : ICart
    {
        private readonly IDbConnection connection;

        public Cart_Context(string cs)
        {
            connection = new System.Data.SqlClient.SqlConnection(cs);
        }

        public void Create(ProductDTO product, int user)
        {
            var sql = "INSERT INTO Cart([UserID], ProductID) VALUES(@User,@Product)";
            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    connection.Query(sql, new { User = user, Product = product.Id});
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

        public void Delete(ProductDTO product, int user)
        {
            var sql = "DELETE FROM Cart WHERE [UserID] = @User AND ProductID = @Product";
            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    connection.Query(sql, new { User = user, Product = product.Id });
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

        public CartDTO GetCart(int user)
        {
            string sql = "SELECT * FROM Cart WHERE UserID = @User";
            List<CartDTO> cartDTOs = new List<CartDTO>();
            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    cartDTOs = connection.Query<CartDTO>(sql, new { User = user }).ToList();
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
            return cartDTOs[1];
        }

        public List<ProductDTO> GetProductsFromCart(int id)
        {
            string sql = "SELECT Product.* FROM Product JOIN Cart on Cart.ProductID = Product.ID WHERE UserID = @id";
            List<ProductDTO> productDTOs = new List<ProductDTO>();

            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    productDTOs = connection.Query<ProductDTO>(sql, new { id = id }).ToList();
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
            return productDTOs;
        }

        public void Update(ProductDTO product, int user)
        {
            var sql = "Update Cart SET Aantal = @aantal WHERE ID = '" + product.Id + "'";
            try
            {
                using (connection)
                {
                    //execute query on database and return result
                    connection.Query<ProductDTO>(sql, new { aantal = product.Stock });
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
    }
}
