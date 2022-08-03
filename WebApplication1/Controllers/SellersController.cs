using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
