var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registers authentication services and adds the Cookie handler to the DI container 
//builder.Services.AddAuthentication() // "MyCookieAuth" not default selected explicitly via .SignInAsync("MyCookieAuth", claimsPrincipal);
builder.Services.AddAuthentication("MyCookieAuth") // Sets "MyCookieAuth" as the default scheme
    .AddCookie("MyCookieAuth", options =>
    {
        options.Cookie.Name = "MyAuthCookie"; // The name of the cookie stored in the user's browser
        //options.LoginPath = "/Account/Login";
    });
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
