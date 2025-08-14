using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
