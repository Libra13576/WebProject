using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using Microsoft.AspNetCore.Http;
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
                                   userlist.CustomerPassword,
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    HttpContext.Session.SetString("CustomerId", details.FirstOrDefault().CustomerId);
                    HttpContext.Session.SetString("CustomerEmail", details.FirstOrDefault().CustomerEmail);
                    HttpContext.Session.SetString("CustomerPassword", details.FirstOrDefault().CustomerPassword);
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
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerEmail,CustomerPassword,CustomerFullname,CustomerAddress,CustomerPhone,Customerphoto")] TblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(tblCustomer);
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
