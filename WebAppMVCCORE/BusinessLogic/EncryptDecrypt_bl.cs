using System.Data;
using System.Data.SqlClient;
using WebAppMVCCORE.Models;
using System.Configuration;
using WebAppMVCCORE.Library;
namespace WebAppMVCCORE.BusinessLogic
{
    public class EncryptDecrypt_bl
    {
        public bool InsertData(ExcryptDecryptModel reg)
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

                    string sql = "sp_insertData";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", reg.Username);
                        cmd.Parameters.AddWithValue("@Password", EncryptionLibrary.EncryptText(reg.Password));
                        cmd.Parameters.AddWithValue("@ConfirmPassword", reg.ConfirmPassword);
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

        public bool Login(string UserName , string Password)
        {
            bool x = false;
            var dbconfig = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();
            string dbconnectionStr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.[tbl_Encryptedpwd] where UserName =@UserName and Password=@Password", con);
                cmd.Parameters.AddWithValue("@UserName",UserName);
                cmd.Parameters.AddWithValue("@Password", EncryptionLibrary.EncryptText( Password));
                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();

                if (idr.HasRows)
                {
                    x = true;
                }
                else
                {
                    x = false;
                }
            }
            return x;
        }
    }
}
