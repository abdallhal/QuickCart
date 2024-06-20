using QuickCart.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using QuickCart.Domain.Mapper;
using QuickCart.Web.AssemblyHandler;
using EntityFrameworkCore.UseRowNumberForPaging;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddAutoMapper(typeof(QuickCartMapper));
AssemblyHandler.HandlehandleDependencies(builder.Services);
builder.Services.AddDbContext<QuickCartDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),o=>o.UseRowNumberForPaging()));        
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
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.Run();
