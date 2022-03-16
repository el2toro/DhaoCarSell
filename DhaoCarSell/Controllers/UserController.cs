using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DhaoCarSell.Controllers
{
    public class UserController : Controller
    {
        public IActionResult GetUser()
        {
            return View();
        }
    }
}
