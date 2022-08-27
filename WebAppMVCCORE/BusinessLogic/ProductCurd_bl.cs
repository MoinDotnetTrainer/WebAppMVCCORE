using System.Data;
using System.Data.SqlClient;
using WebAppMVCCORE.Models;
using System.Configuration;
namespace WebAppMVCCORE.BusinessLogic
{
    public class ProductCurd_bl
    {
        public IConfigurationRoot GetConnection()
        {
            var builder  = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder;
        }
        private SqlConnection con;
        //To Handle connection related activities    

        public List<Product> GetAllProducts()
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            List<Product> productList = new List<Product>();

            using (SqlConnection con = new SqlConnection(connection))
            {

                SqlCommand com = new SqlCommand("SP_Get_ProductList", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {

                    productList.Add(

                        new Product
                        {

                            Id = Convert.ToInt32(dr["Id"]),
                            ProductName = Convert.ToString(dr["ProductName"]),
                            ProductDescription = Convert.ToString(dr["ProductDescription"]),
                            ProductCost = Convert.ToDecimal(dr["ProductCost"]),
                            Stock = Convert.ToInt32(dr["Stock"])

                        }
                        );
                }

                return productList;
            }
        }

        public bool InsertProduct(Product product)
        {
                var dbconfig = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json").Build();
                string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
                using (SqlConnection con = new SqlConnection(dbconnectionStr))
                {
                    if (!string.IsNullOrEmpty(dbconfig.ToString()))
                    {
                        dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
                       
                            string sql = "SP_Add_New_Product";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                                cmd.Parameters.AddWithValue("@ProductCost", product.ProductCost);
                                cmd.Parameters.AddWithValue("@Stock", product.Stock);
                                con.Open();
                                int x = cmd.ExecuteNonQuery();
                                if (x >= 1)
                                {         
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                           }                    
                    }
                }
            return true;
        }

        public Product GetProductsByID(int id)
        {
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            Product productList = new Product();

            using (SqlConnection con = new SqlConnection(dbconnectionStr))
            {

                SqlCommand com = new SqlCommand("SP_Get_Product_By_Id", con);
                com.Parameters.AddWithValue("@id", id);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    productList.Id = Convert.ToInt32(dr["Id"]);
                    productList.ProductName = Convert.ToString(dr["ProductName"]);
                    productList.ProductDescription = Convert.ToString(dr["ProductDescription"]);
                    productList.ProductCost = Convert.ToDecimal(dr["ProductCost"]);
                    productList.Stock = Convert.ToInt32(dr["Stock"]);

                }

                return productList;
            }
        }

        public bool UpdateProduct(Product product)
        {
            var dbconfig = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();
            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionStr))
            {
                if (!string.IsNullOrEmpty(dbconfig.ToString()))
                {
                    dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];

                    string sql = "SP_Update_Product";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", product.Id);
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                        cmd.Parameters.AddWithValue("@ProductCost", product.ProductCost);
                        cmd.Parameters.AddWithValue("@Stock", product.Stock);
                        con.Open();
                        int x = cmd.ExecuteNonQuery();
                        if (x >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var dbconfig = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();
            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionStr))
            {
                if (!string.IsNullOrEmpty(dbconfig.ToString()))
                {
                    dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];

                    string sql = "SP_Delete_Product_By_Id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        int x = cmd.ExecuteNonQuery();
                        if (x >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}



