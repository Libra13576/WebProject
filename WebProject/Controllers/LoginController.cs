using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {
        private FPTBookContext _context;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(TblCustomer customer)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in _context.TblCustomers
                               where userlist.CustomerEmail == customer.CustomerEmail && userlist.CustomerPassword == customer.CustomerPassword
                               select new
                               {
                                   userlist.CustomerId,
                                   userlist.CustomerEmail,
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    HttpContext.Session.SetString("CustomerId", details.FirstOrDefault().CustomerId);
                    HttpContext.Session.SetString("CustomerEmail", details.FirstOrDefault().CustomerEmail);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(customer);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(TblCustomer customer)
        {
            if (ModelState.IsValid)
            {
                _context.TblCustomers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
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
