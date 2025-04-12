using DEPI_V2.Data;
using DEPI_V2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Identity Core services
builder.Services.AddIdentityCore<User>();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Add Identity
builder.Services.AddIdentity<User, IdentityRole>(Options =>
{
    Options.SignIn.RequireConfirmedAccount = false;
    Options.SignIn.RequireConfirmedEmail = false;
    Options.User.RequireUniqueEmail = true;
    Options.SignIn.RequireConfirmedPhoneNumber = false;
    Options.Password.RequireNonAlphanumeric = false;
    Options.Password.RequiredLength = 8;
    Options.Password.RequireUppercase = false;
    Options.Password.RequireLowercase = false;
    Options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();






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

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
