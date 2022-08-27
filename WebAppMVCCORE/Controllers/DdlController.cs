using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.BusinessLogic;
using WebAppMVCCORE.Models;
namespace WebAppMVCCORE.Controllers
{
    public class DdlController : Controller
    {
        ddlproduct_bl obj = new ddlproduct_bl();

        [HttpGet]
        public IActionResult GetAllDataOnDdl()
        {
            ddlProductModelclass objFS = new ddlProductModelclass();

            objFS.ListDepartment = BindListlistDepartment();
            objFS.ListDepartmentbyID = BindProductByID("Laptops");

            return View(objFS);
        }

        [HttpPost]
        public IActionResult GetAllDataOnDdl(ddlProductModelclass obj1)
        {
            ViewData["x"] = obj1.id;

            ViewData["Val"]= obj.GetProductListById(obj1.id);

            return View();
        }

        [NonAction] // if Method is not Action method then use NonAction
        public List<ddlProductModelclass> BindListlistDepartment()
        {
            List<ddlProductModelclass> ListofDept = new List<ddlProductModelclass>()
            {
                new ddlProductModelclass
                {
                         id = 0,
                         product_name = "Select"
                }
            };
            foreach (var item in obj.GetCustomerList())
            {
                ddlProductModelclass sm = new ddlProductModelclass();
                sm.id = item.id;
                sm.product_name = item.product_name;
                ListofDept.Add(sm);
            }
            return ListofDept;

        }

        [NonAction] // if Method is not Action method then use NonAction
        public List<ddlProductModelclass> BindProductByID(string product_name)
        {
            List<ddlProductModelclass> ListofDept = new List<ddlProductModelclass>()
            { new
            ddlProductModelclass
            {
                id = 0,
                product_name = "Select"
            } };
            foreach (var item in obj.GetProductListByName(product_name))
            {
                ddlProductModelclass sm = new ddlProductModelclass();
                sm.id = item.id;
                sm.product_name = item.product_name;
                ListofDept.Add(sm);
            }
            return ListofDept;

        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Fruits = obj.PopulateData();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string x)
        {
            string res = Request.Form["test"].ToString(); 
            return View();
        }

    }
}
