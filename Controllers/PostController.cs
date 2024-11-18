using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingAflevering.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
