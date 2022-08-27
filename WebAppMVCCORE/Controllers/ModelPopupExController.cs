   using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.BusinessLogic;
using WebAppMVCCORE.Models;

namespace WebAppMVCCORE.Controllers
{
    public class ModelPopupExController : Controller
    {
        ModelPopup_bl obj = new ModelPopup_bl();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ModelpopUp ex)
        {
            if (ModelState.IsValid)
            {
                bool res = obj.InsertModelData(ex);
                if (res)
                {
                    return View();
                }
                else
                {
                    ViewData["res"] = "Something Went Wrong!";
                }
            }
            return View();
        }

    }
}
