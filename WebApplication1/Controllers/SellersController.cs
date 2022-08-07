using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class SellersController : Controller


    {
        private readonly SellerService _sellerService;

        public SellersController (SellerService sellerService)//Injeção de dependencia

        {
        _sellerService = sellerService;
        }

        public IActionResult Index() // exemplo MVC
        {
            var list = _sellerService.FindALL();//Retonrna uma lista de Seller
            return View(list);
        }
    }
}
