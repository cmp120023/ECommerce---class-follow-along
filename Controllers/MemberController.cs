using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class MemberController : Controller
    {
        private readonly ProductDbContext _context;

        public MemberController(ProductDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel reg)
        {
            if (ModelState.IsValid)
            {
                Member newMember = new()
                {
                    Username = reg.Username,
                    Email = reg.Email,
                    Password = reg.Password,
                    DateOfBirth = reg.DateOfBirth,
                };
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(reg);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Member? loggedInMember = await _context.Members
                    .Where(m => (m.Username == login.UsernameOrEmail || m.Email == login.UsernameOrEmail)
                    && m.Password == login.Password)
                    .SingleOrDefaultAsync();

                if(loggedInMember == null)
                {
                    ModelState.AddModelError(string.Empty, "incorrect email or password");
                    return View(login);
                }

                HttpContext.Session.SetString("Username", loggedInMember.Username);
                HttpContext.Session.SetInt32("Id", loggedInMember.MemberId);

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
