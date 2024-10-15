using Microsoft.AspNetCore.Mvc;
using Project2Store.ShopUI.Models;

namespace Project2Store.ShopUI.Components
{
    public class CategorySideBoxViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;

        public CategorySideBoxViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IViewComponentResult Invoke()
        {
            var currentCategory = RouteData?.Values["category"];
            ViewBag.Category = currentCategory;
            return View(productRepository.GetAllCategories());
        }
    }
}
