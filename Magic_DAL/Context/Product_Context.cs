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
        private readonly Database connection;

        public Product_Context(string cs)
        {
            connectionstring = cs;
            connection = new Database(connectionstring);
        }

        //GetAll
        public List<ProductDTO> Getproducts()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            List<ProductDTO> lijst = new List<ProductDTO>();
            DataTable dt = new();
            SqlDataAdapter da = new("SELECT * from Product", connectionstring);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lijst.Add(new ProductDTO(Convert.ToInt32(dr["ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Color"]), Convert.ToInt32(dr["Stock"])));
            }
            connection.Close();
            return lijst;
        }
        public void Create(ProductDTO product)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command;
            string sql = "INSERT INTO Product(Name, Color, Stock) VALUES(" +
                "@Name," +
                "@Color," +
                "@Stock)";

            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Color", product.Color);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command;
            string sql = "DELETE FROM Product WHERE ID = @ID";

            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(ProductDTO product)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command;
            string sql = "Update Product SET " +
                "Name = @Name," +
                "Color = @Color," +
                "Stock = @Stock " +
                "WHERE ID = '" + product.Id + "'";

            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Color", product.Color);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public ProductDTO GetProductById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string sql = "SELECT * FROM Product WHERE ID = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            connection.Close();
            return new ProductDTO(reader.GetInt32("ID"), reader.GetString("Name"), reader.GetString("Color"), reader.GetInt32("Stock"));
        }
    }
}
