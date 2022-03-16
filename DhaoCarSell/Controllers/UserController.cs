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

        public IActionResult GetAll()
        {
            return View();
        }

        public IActionResult GetUserByName()
        {
            return View();
        }

        public IActionResult GetUserById()
        {
            return View("hgjfdh");
        }
    }
}
