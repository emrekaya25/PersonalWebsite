using Microsoft.AspNetCore.Authentication.Cookies;
using PersonalWebsite.UI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    // Di�er kimlik do�rulama ayarlar�n� burada yapabilirsiniz.
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    // Di�er cookie ayarlar�n� burada yapabilirsiniz.
});

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient();
builder.Services.AddAuthorization(); // Yetkilendirme servisini ekleyin

var app = builder.Build();

// HTTP request pipeline'�n� yap�land�r�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); // Routing middleware'ini ekleyin

app.UseAuthentication(); // Yetkilendirme middleware'ini ekleyin
app.UseAuthorization(); // Yetkilendirme middleware'ini ekleyin (UseAuthentication'dan sonra olmal�d�r)

app.UseSession();
app.UseMiddleware<LoginCheckMiddleware>(); // �zel yetkilendirme middleware'ini ekleyin

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");
});

app.Run();

