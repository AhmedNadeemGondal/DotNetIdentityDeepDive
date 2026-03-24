using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DotNetIdentityDeepDive.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            // Verifying credentials
            if(Credential.UserName == "admin"
                && Credential.Password == "password")
            {
                // Creating security context as the credentials above are verified

                // manually adding the following claims for demo purpose
                // this is usually handled more gracefully
                List<Claim> claims = [
                new(ClaimTypes.Name, "admin"),
                new(ClaimTypes.Email, "admin@mywebsite.com"),
                new("Department", "HR"),
                new("Admin", "true"),
                new("Manager", "true"),
                new("EmploymentDate", "2025-12-22")
                ];
                // Creating an identity in light of the claims
                ClaimsIdentity identity = new(claims, "MyCookieAuth"); // Note that passing "MyCookieAuth" (the authentication type)
                                                                       // into the ClaimsIdentity constructor is vital
                ClaimsPrincipal claimsPrincipal = new(identity); // This contains the security context

                // SignInAsync wraps Principal in an 'AuthenticationTicket' containing your claims and 
                // metadata, then protects (encrypts) that ticket via the Data Protection API.
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal); // 1. This will wrap and serialize the claims principal
                                                                                //    and any AuthenticationProperties/metadata into a string
                                                                                // 2. Encrypt that string
                                                                                // 3. Save it as a cookie in the HttpContext object
                                                                                // 4. The requires .AddAuthentication().AddCookie()
                                                                                //    in the configure services section, please see there
                                                                                // 5. All this will return a cookie that is parsed by the
                                                                                //    browser and can be ssen in the Cookies
                return RedirectToPage("/Index");
            }

            return Page();
        }

    }

    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
