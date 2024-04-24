using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppRazorPages.Model.AuthApp;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext db;
        public AccountController(AppDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AuthUser user = db.AuthSamolet.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null)
                {
                    Authenticate(model.Name); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AuthUser user = db.AuthSamolet.FirstOrDefault(u => u.Name == model.Name);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.AuthSamolet.Add(new AuthUser { Name = model.Name, Password = model.Password });
                    db.SaveChangesAsync();

                    Authenticate(model.Name); // аутентификация

                    return RedirectToPage("/Index");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
