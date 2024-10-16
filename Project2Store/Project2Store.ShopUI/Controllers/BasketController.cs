using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project2Store.ShopUI.Models;

namespace Project2Store.ShopUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductRepository productRepository;

        public BasketController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(string returnUrl)
        {
            BasketPageViewModel basketPageViewModel = new BasketPageViewModel()
            {
                Basket = GetBasket(),
                ReturnUrl = returnUrl
            };
            return View(basketPageViewModel);
        }

        [HttpPost]
        public IActionResult AddToBasket(long productId, string returnUrl)
        {
            var product = productRepository.GetById(productId);
            var basket = GetBasket();
            basket.Add(product, 1);
            SaveBasket(basket);
            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }

        public IActionResult RemoveFromBasket(long productId, string returnUrl)
        {
            var product = productRepository.GetById(productId);
            var basket = GetBasket();
            basket.Remove(product);
            SaveBasket(basket);
            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }

        private Basket GetBasket()
        {
            var basketString = HttpContext.Session.GetString("Basket");
            if (string.IsNullOrEmpty(basketString))
            {
                return new Basket();
            }
            return JsonConvert.DeserializeObject<Basket>(basketString);
        }

        private void SaveBasket(Basket basket)
        {
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
        }
    }
}