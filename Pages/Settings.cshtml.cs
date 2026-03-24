using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetIdentityDeepDive.Pages
{
    [Authorize(Policy = "AdminOnly")] // This requies the AdminOnly claim to be present in the identity
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
