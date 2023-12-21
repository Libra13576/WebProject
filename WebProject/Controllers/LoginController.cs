using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(TblCustomer customer)
        {

            return View();
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
