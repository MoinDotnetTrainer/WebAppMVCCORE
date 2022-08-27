using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.Models;
using WebAppMVCCORE.BusinessLogic;
namespace WebAppMVCCORE.Controllers
{
    public class ENcryptDecryptExController : Controller
    {
        EncryptDecrypt_bl obj = new EncryptDecrypt_bl();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(ExcryptDecryptModel Registration)
        {
            obj.InsertData(Registration);

            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ExcryptDecryptModel Registration)
        {
           bool  x =  obj.Login(Registration.Username,Registration.Password);
            if (x == true)
            {
                return RedirectToAction("Registration");
            }
            else
            {
                return Content("No Data");
            }
        }

    }
}
