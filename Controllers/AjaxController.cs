using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingAflevering.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
