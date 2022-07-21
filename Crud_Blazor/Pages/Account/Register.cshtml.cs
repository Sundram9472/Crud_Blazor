using Crud_Blazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Crud_Blazor.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AppDBContext _Context;

        public RegisterModel(AppDBContext context)
        {
            _Context = context;
        }
        public string ReturnUrl { get; set; }

        [BindProperty]
        public LoginModal resgisterModal { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            string returnUrl = Url.Content("./Login");
            _Context.loginModal.Add(resgisterModal);
            await _Context.SaveChangesAsync();
            return LocalRedirect("~/");
        }
    }
}
