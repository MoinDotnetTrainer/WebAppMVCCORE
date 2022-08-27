using System.Data;
using System.Data.SqlClient;
using WebAppMVCCORE.Models;
using System.Configuration;

namespace WebAppMVCCORE.BusinessLogic
{
    public class ModelPopup_bl
    {
        public bool InsertModelData(ModelpopUp m)
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

                    string sql = "Insert into tbl_ModelPopupInsert values(@name,@country)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                      
                        cmd.Parameters.AddWithValue("@name", m.Name);
                        cmd.Parameters.AddWithValue("@country", m.Country);
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
