using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.Extension;
using WebAppCore.Helper;
using WebAppCore.Models;
using WebAppCore.ModelViews;

namespace WebAppCore.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SqlwebchivalryContext _context;

        public AccountController(SqlwebchivalryContext context)
        {
            _context = context;
        }
        [Route("Register.html", Name = "Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register.html", Name = "Register")]
        public async Task<IActionResult> Register(RegisterViewModel taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string salt = Utilities.GetRandomKey();
                    Customer khachhang = new Customer
                    {
                        FullName = taikhoan.FullName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Password = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Active = true,
                        Salt = salt,
                        CreateDate = DateTime.Now
                    };

                    _context.Add(khachhang);
                    await _context.SaveChangesAsync();

                    HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachhang.FullName),
                        new Claim("CustomerId", khachhang.CustomerId.ToString())
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Login", "Account");
                }
            }
            catch
            {
                return RedirectToAction("Clause", "Account");
            }
            return View(taikhoan);
        }

        [Route("Login.html", Name = "Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Login.html", Name = "Login")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
 
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail)
                        return View(customer);
                    var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);
                    if (khachhang == null)
                    return RedirectToAction("Register", "Account");

                    string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
                    if (khachhang.Password != pass)
                    {
                        return View(customer);
                    }
                    if (khachhang.Active == false)
                    {
                        return RedirectToAction("Clause", "Account");
                    }
                    HttpContext.Session.SetString("UserEmail", khachhang.Email);

                    HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, khachhang.FullName),
                new Claim("CustomerId", khachhang.CustomerId.ToString())
            };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Clause", "Account");
                }
            }
            catch
            {
                return RedirectToAction("Register", "Account");
            }

            return View(customer);
        }
        [Route("Logout", Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }
        [Route("Clause.html", Name = "Clause")]
        public IActionResult Clause()
        {
                    return View();
        }

    }
}
