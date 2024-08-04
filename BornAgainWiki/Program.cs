using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ronin.Api.Model;
using UnnamedStudios.Common.Model;
using UnnamedStudios.Common;
using UnnamedStudios.Common.Providers;
using UnnamedStudios.Common.DependencyInjection;
using BornAgainWiki.Providers;

TemporaryDiskStorageProvider.DeleteTemporaryData(".temp");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddCommon();
builder.Services.AddSingleton(new RoninApiClient(new ServiceClientOptions("https://api.bornagain.gg")));
builder.Services.AddSingleton(x => new TemporaryDiskStorageProvider(".temp"));
builder.Services.AddSingleton<GameDataProvider>();

// Add Sidebar menu json file
builder.Configuration.AddJsonFile("sidebar.json", optional: true, reloadOnChange: true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();
app.MapFallback(context => {
	context.Response.Redirect("/Pages/ErrorPage");
	return Task.CompletedTask;
});
app.Run();
