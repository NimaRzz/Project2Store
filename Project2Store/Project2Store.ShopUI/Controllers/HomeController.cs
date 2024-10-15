using Microsoft.AspNetCore.Mvc;
using Project2Store.ShopUI.Models;

namespace Project2Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private int pageSize = 4;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(int pageNumber = 1, string category = "")
        {
            var viewModel = new ProductListViewModel()
            {
                CurrentCategory = category,
                Data = productRepository.GetAll(pageNumber, pageSize, category)
            };
            return View(viewModel);
        }
    }
}
