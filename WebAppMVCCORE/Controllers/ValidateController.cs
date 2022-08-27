using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.Models;
namespace WebAppMVCCORE.Controllers
{
    public class ValidateController : Controller
    {
       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ValidateModelClass webUser)
        {
            if (ModelState.IsValid)
                return Content("Thank you!");
            else
                return Content("Model could not be validated!");
        }
    }
}
