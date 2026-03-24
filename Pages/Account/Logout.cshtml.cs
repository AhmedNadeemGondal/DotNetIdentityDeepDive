using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetIdentityDeepDive.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("MyCookieAuth"); // This is an extension method that will delete the cookie
                                                            // effectively logging the user out.
            return RedirectToPage("/Index");
                
         }
    }
}
