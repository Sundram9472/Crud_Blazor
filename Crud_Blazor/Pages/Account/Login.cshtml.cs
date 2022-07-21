using System;
using Crud_Blazor.Data;
using Crud_Blazor.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Crud_Blazor.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly AppDBContext _Context;

        public LoginModel(AppDBContext context)
        {
            _Context = context;
        }
        public string ReturnUrl { get; set; }

        [BindProperty]
        public LoginModal modal { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync(LoginModal modal)
        {
            string returnUrl = Url.Content("~/");

            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var loginResponse = await _Context.loginModal.Where(x => x.UserName == modal.UserName && x.PassWord ==modal.PassWord).ToListAsync();
           
            if (loginResponse.Count > 0)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, modal.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };

                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                   
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}
