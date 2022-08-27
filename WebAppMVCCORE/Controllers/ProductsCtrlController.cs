using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.BusinessLogic;
using WebAppMVCCORE.Models;
namespace WebAppMVCCORE.Controllers
{
    public class ProductsCtrlController : Controller
    {
        ProductCurd_bl obj = new ProductCurd_bl();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return View(obj.GetAllProducts());
        }

        [HttpGet]
        public ActionResult InsertProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                bool res = obj.InsertProduct(p);
                if (res)
                {
                    return RedirectToAction("GetAllProducts");
                }
                else
                {
                    ViewData["res"] = "Something Went Wrong!";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateProduct(int? id)
        {
            return View(obj.GetProductsByID((int)id));
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                bool res = obj.UpdateProduct(p);
                if (res)
                {
                    return RedirectToAction("GetAllProducts");
                }
                else
                {
                    ViewData["res"] = "Something Went Wrong!";
                }
            }
            return View();
        }

        public ActionResult DeleteProduct(int id)
        {

            bool res = obj.DeleteProduct(id);
            if (res)
            {
                return RedirectToAction("GetAllProducts");
            }
            else
            {
                ViewData["res"] = "Something Went Wrong!";
            }

            return View();

        }

        [HttpGet]
        public IActionResult PassMultipleValues(int id, string productname)
        {
            ViewData["id"] = id;
            ViewData["Name"] = productname;
            return View();
        }

        [HttpGet]
        public IActionResult SuccessPopup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SuccessPopup(Product p)
        {
            return View();
        }

        [HttpGet]
        public IActionResult SuccessPopup1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SuccessPopup1(Product p)
        {
            
            return View();
        }
    }
       
}
