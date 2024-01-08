using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MVCAbit.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MVCAbit.Models;

namespace MVCAbit.Controllers
{
    public class AccountController : Controller
    {
        private AbiturientsContext db; 

        public AccountController(AbiturientsContext context)
        {
            db = context;
        }

        public IActionResult IndexAdmin()
        {
            return View();
        }

        public IActionResult IndexOperator()
        {
            return View();
        }

        public IActionResult IndexChecker()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login); // аутентификация
                    
                    if (model.Login=="alexey")
                    {
                        return RedirectToAction("IndexAdmin", "Account");
                    }
                    if (model.Login=="OperatorDigit")
                    {
                        return RedirectToAction("IndexOperator", "Account");
                    }
                    if (model.Login == "CheckerDigit")
                    {
                        return RedirectToAction("IndexChecker", "Account");
                    }

                }
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
            return RedirectToAction("Login", "Account");
        }
    }
}