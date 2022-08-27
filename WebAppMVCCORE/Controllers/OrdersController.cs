using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.Models;
using WebAppMVCCORE.BusinessLogic;
namespace WebAppMVCCORE.Controllers
{
    public class OrdersController : Controller
    {
        Orders_bl obj1 = new Orders_bl();
        [HttpGet]
        public IActionResult GetData()
        { //creating Tuple and passing two select list item in that.  

            //OrdersModelClass x = new OrdersModelClass();
            //x.listCustomer = BindCustomers();
            //return View(x);
            return View();
        }

        [HttpPost]
        public IActionResult GetData(OrdersModelClass x)
        {
            return View(obj1.GetAllOrdersByID(Request.Form["Data"].ToString()));
        }

        [NonAction] // if Method is not Action method then use NonAction
        public List<OrdersModelClass> BindCustomers()
        {
            List<OrdersModelClass> ListofDept = new List<OrdersModelClass>()
            { new
            OrdersModelClass
            {
                CustomerID = "Select"
            } };
            foreach (var item in obj1.GetCustomer())
            {
                OrdersModelClass sm = new OrdersModelClass();

                sm.CustomerID = item.CustomerID;
                ListofDept.Add(sm);
            }
            return ListofDept;

        }


        [HttpGet]
        public IActionResult Data()
        {
            OrdersModelClass x = new OrdersModelClass();
            x.listCustomer = BindCustomers();
            return View(x);
        }
    }
}
