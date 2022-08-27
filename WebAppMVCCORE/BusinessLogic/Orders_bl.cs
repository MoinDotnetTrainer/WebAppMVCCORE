using System.Data;
using System.Data.SqlClient;
using WebAppMVCCORE.Models;
using System.Configuration;
namespace WebAppMVCCORE.BusinessLogic
{
    public class Orders_bl
    {
        public IConfigurationRoot GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder;
        }

        public List<OrdersModelClass> GetCustomer()
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Select  distinct CustomerID from dbo.orders", con);
            con.Open();
            SqlDataReader idr = cmd.ExecuteReader();
            List<OrdersModelClass> customers = new List<OrdersModelClass>();
            if (idr.HasRows)
            {
                while (idr.Read())
                {
                    customers.Add(new OrdersModelClass
                    {
                        CustomerID = idr["CustomerID"].ToString(),
                    });
                }
            }
            con.Close();
            return customers;
        }
        public List<OrdersModelClass> GetAllOrdersByID(string CustomerID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            List<OrdersModelClass> ordersList = new List<OrdersModelClass>();

            using (SqlConnection con = new SqlConnection(connection))
            {

                SqlCommand com = new SqlCommand("sp_getOrdersbyCustomer", con);
                com.Parameters.AddWithValue("@CustomerID" , CustomerID);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {

                    ordersList.Add(

                        new OrdersModelClass
                        {

                            OrderID = Convert.ToInt32(dr["OrderID"]),
                            CustomerID = Convert.ToString(dr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(dr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(dr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(dr["ShippedDate"]),
                            ShipVia = Convert.ToInt32(dr["ShipVia"]),
                            Freight = Convert.ToDecimal(dr["Freight"]),
                            ShipName = Convert.ToString(dr["ShipName"])

                        }
                        );
                }

                return ordersList;
            }
        }
    }
}
