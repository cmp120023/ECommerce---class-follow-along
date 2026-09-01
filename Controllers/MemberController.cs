using Ecommerce.Data;
using Ecommerce.Models;
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
    }
}
