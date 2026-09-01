using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class MemberController : Controller
    {
       public IActionResult Register()
        {
            return View();
        }
    }
}
