using Cadastro_contatos.DataBases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Pomelo.EntityFrameworkCore.MySql;
using System.Configuration;

//public void ConfigureServices(IServiceCollection services)
//{
//    services.Configure<CookiePolicyOptions>(options =>
//    {
//        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//        options.CheckConsentNeeded = context => true;
//        options.MinimumSameSitePolicy = SameSiteMode.None;
//    });

//    //adicionando o serviço de cookies na aplicação
//    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie(options => options.LoginPath = "/Usuario/Index");

//    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//}

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MariaDB");
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication("Identity.Login")
    .AddCookie("Identity.Login", config =>
    {
        config.Cookie.Name = "Identity.Login";
        config.LoginPath = "/Contatos";
        config.AccessDeniedPath = "/Principal";
        config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Principal}/{action=Index}/{id?}");

app.Run();
