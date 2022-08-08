using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
