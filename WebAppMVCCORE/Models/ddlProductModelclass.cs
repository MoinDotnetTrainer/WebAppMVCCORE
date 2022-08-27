namespace WebAppMVCCORE.Models
{
    public class ddlProductModelclass
    {
        public int id { get; set; }
        
        public string? product_name { get; set; }

        public List<ddlProductModelclass> ListDepartment { get; set; }
        public List<ddlProductModelclass> ListDepartmentbyID { get; set; }
    }
}
