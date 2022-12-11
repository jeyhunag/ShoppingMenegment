using Microsoft.EntityFrameworkCore;
using ShoppingMenegment.Models;
using ShoppingMenegment.Models.Data;
using Microsoft.AspNetCore.Identity;
using ShoppingMenegment.Models.Entity.Membership;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



builder.Services.AddDbContext<ShoppingMenegmentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingMenegmentContextConnection"));
});



builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ShoppingMenegmentContext>();

builder.Services.AddScoped<SignInManager<AppUser>>();

builder.Services.AddScoped<UserManager<AppUser>>();

builder.Services.AddScoped<RoleManager<AppRole>>();

builder.Services.AddAuthentication();


builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.Cookie.Name = "Shopping-Managment";
    cfg.Cookie.HttpOnly = true;
    cfg.ExpireTimeSpan = new TimeSpan(0, 30, 0);
});

builder.Services.Configure<IdentityOptions>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequiredLength = 3;
    cfg.Password.RequiredUniqueChars = 1;
    cfg.Password.RequireUppercase = false;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
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
app.Seed();
app.UseAuthentication();;

app.UseAuthorization();


app.MapAreaControllerRoute("adminArea",
                areaName: "Admin",
                pattern: "admin/{controller=Admin}/{action=Index}/{id?}");



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();

app.Run();
