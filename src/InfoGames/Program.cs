using InfoGames.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var _jogo = builder.Build();

// Configure the HTTP request pipeline.
if (!_jogo.Environment.IsDevelopment()) {
    _jogo.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _jogo.UseHsts();
}

_jogo.UseHttpsRedirection();
_jogo.UseStaticFiles();

_jogo.UseRouting();

_jogo.UseAuthorization();

_jogo.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

_jogo.Run();
