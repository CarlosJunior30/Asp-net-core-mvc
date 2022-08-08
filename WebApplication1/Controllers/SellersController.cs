using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class SellersController : Controller


    {
        private readonly SellerService _sellerService;
        public readonly DepartmentService _departmentService;

        public SellersController (SellerService sellerService, DepartmentService departmentService)//Injeção de dependencia

        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() // exemplo MVC
        {
            var list = _sellerService.FindALL();//Retonrna uma lista de Seller
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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
