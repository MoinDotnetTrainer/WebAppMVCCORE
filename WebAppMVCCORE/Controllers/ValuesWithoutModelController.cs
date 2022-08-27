using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCCORE.Controllers
{
    public class ValuesWithoutModelController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string x)
        {
            string Name = Request.Form["txtfirstname"].ToString();
            string area = Request.Form["txtarea"].ToString();
            string Password = Request.Form["txtpwd"].ToString();
            string gender = Request.Form["Gender"].ToString();
            string Dept = Request.Form["DDlDept"].ToString();
            return View();

        }
    }
}
