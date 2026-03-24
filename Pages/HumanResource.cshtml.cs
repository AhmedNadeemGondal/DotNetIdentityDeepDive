using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetIdentityDeepDive.Pages
{
    [Authorize(Policy = "MustBelongToHR")]
    public class HumanResourceModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
