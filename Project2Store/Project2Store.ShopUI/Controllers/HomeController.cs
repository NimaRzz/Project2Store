using Microsoft.AspNetCore.Mvc;

namespace Project2Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
