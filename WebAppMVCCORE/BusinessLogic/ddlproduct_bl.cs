using System.Data;
using System.Data.SqlClient;
using WebAppMVCCORE.Models;

namespace WebAppMVCCORE.BusinessLogic
{
    public class ddlproduct_bl
    {
        public IConfigurationRoot GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder;
        }
        public List<ddlProductModelclass> GetCustomerList()
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Product_Master", con);
            con.Open();
            SqlDataReader idr = cmd.ExecuteReader();
            List<ddlProductModelclass> customers = new List<ddlProductModelclass>();
            if (idr.HasRows)
            {
                while (idr.Read())
                {
                    customers.Add(new ddlProductModelclass
                    {
                        id = Convert.ToInt32(idr["id"]),
                        product_name = Convert.ToString(idr["product_name"]),
                    });
                }
            }
            con.Close();
            return customers;
        }

        public  List<ddlProductModelclass> GetProductListByName(string? product_name)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Product_Master where product_name=@product_name", con);
            cmd.Parameters.AddWithValue("@product_name", product_name);
            con.Open();
            SqlDataReader idr = cmd.ExecuteReader();
            List<ddlProductModelclass> customers = new List<ddlProductModelclass>();
            if (idr.HasRows)
            {
                while (idr.Read())
                {
                    customers.Add(new ddlProductModelclass
                    {
                        id = Convert.ToInt32(idr["id"]),
                        product_name = Convert.ToString(idr["product_name"]),
                    });
                }
            }
            con.Close();
            return customers;
        }
        public List<ddlProductModelclass> GetProductListById(int? id)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Product_Master where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader idr = cmd.ExecuteReader();
            List<ddlProductModelclass> customers = new List<ddlProductModelclass>();
            if (idr.HasRows)
            {
                while (idr.Read())
                {
                    customers.Add(new ddlProductModelclass
                    {
                        id = Convert.ToInt32(idr["id"]),
                        product_name = Convert.ToString(idr["product_name"]),
                    });
                }
            }
            con.Close();
            return customers;
        }


        public  List<ddlProductModelclass> PopulateData()
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            List<ddlProductModelclass> fruits = new List<ddlProductModelclass>();
           
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "Select * from dbo.Product_Master";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                   
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            fruits.Add(new ddlProductModelclass
                            {
                                
                                id = Convert.ToInt32(sdr["id"]),
                                product_name = Convert.ToString(sdr["product_name"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return fruits;
        }
    }
}
