using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    /// <summary>
    /// Handles user account life cycles, including visitor registration, credential validation login sessions, and sign-out flushing.
    /// </summary>
    public class MemberController : Controller
    {
        /// <summary>
        /// The active database context used for communicating with the underlying SQL database storage.
        /// </summary>
        private readonly ProductDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class and injects the database dependency.
        /// </summary>
        /// <param name="context">The application's active database context instance.</param>
        public MemberController(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: /Member/Register
        /// Displays a blank account signup form page to public store traffic visitors.
        /// </summary>
        /// <returns>A form view for inputting user account registration properties.</returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// POST: /Member/Register
        /// Validates, maps, and asynchronously commits a newly registered user profile entity to the tracking data rows.
        /// </summary>
        /// <param name="reg">The registration checklist model carrying user credentials submitted from the HTML layout.</param>
        /// <returns>A redirect to the landing dashboard layout on success, or the form with specific property validation highlights.</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel reg)
        {
            if (ModelState.IsValid)
            {
                Member newMember = new()
                {
                    Username = reg.Username,
                    Email = reg.Email,
                    Password = reg.Password, // Note: In a production app, we would scramble/hash this password for safety!
                    DateOfBirth = reg.DateOfBirth,
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(reg);
        }

        /// <summary>
        /// GET: /Member/Login
        /// Displays the account sign-in interface form layout to returning users.
        /// </summary>
        /// <returns>The secure login layout field template view.</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// POST: /Member/Login
        /// Validates login credentials against existing database records and stores identification markers in session memory cookies.
        /// </summary>
        /// <param name="login">The sign-in request configuration block carrying identity and secret key strings.</param>
        /// <returns>A dashboard destination redirect upon authentication, or a reloaded error block frame entry page.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Member? loggedInMember = await _context.Members
                    .Where(m => (m.Username == login.UsernameOrEmail || m.Email == login.UsernameOrEmail)
                    && m.Password == login.Password)
                    .SingleOrDefaultAsync();

                if (loggedInMember == null)
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

        /// <summary>
        /// GET: /Member/LogOut
        /// Destroys active persistent authentication identifiers inside cookie session tracking states and signs the user out.
        /// </summary>
        /// <returns>A redirect jumping straight back to the landing dashboard interface layout as a guest visitor.</returns>
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
