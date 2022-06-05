using DhaoCarSell.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;


namespace DhaoCarSell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //TODO IoC Dependancy Injection
        public IActionResult Index()
        {
            var query = new CarData();
            var cars = query.GetCars();

            return View(cars);
        }        
      
        public IActionResult CarDetails(int id)
        {
            var query = new CarData();
            var model = query.GetCarById(id);

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }  

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
