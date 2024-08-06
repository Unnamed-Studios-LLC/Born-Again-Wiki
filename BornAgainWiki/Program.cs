using BornAgainWiki.Providers;
using BornAgainWiki.Rules;
using Ronin.Api.Model;
using UnnamedStudios.Common.AspNetCore;
using UnnamedStudios.Common.Model;
using UnnamedStudios.Common.Providers;
using UnnamedStudios.Common.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
using Zero.Service.Model;
using BornAgainWiki;
using System.Security.Cryptography.X509Certificates;


TemporaryDiskStorageProvider.DeleteTemporaryData(".temp");

var settings = ZeroConfiguration.GetConfiguration<WikiSettings>();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddCommon();
builder.Services.AddSingleton(new RoninApiClient(new ServiceClientOptions(settings.Url.BornAgainApi)));
builder.Services.AddSingleton(x => new TemporaryDiskStorageProvider(".temp"));
builder.Services.AddSingleton<ApiFileProvider>();
builder.Services.AddSingleton<ObjectLibraryProvider>();
builder.Services.AddSingleton<TextureProvider>();
builder.Services.AddTransient(x => ZeroConfiguration.GetConfiguration<WikiSettings>());

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Add Sidebar menu json file
builder.Configuration.AddJsonFile("sidebar.json", optional: true, reloadOnChange: true);

// Https setup
builder.WebHost.ConfigureHttps((context, configureAction) =>
{
	if (context.HostingEnvironment.IsProduction())
	{
		if (File.Exists(settings.Https.CertificatePath))
		{
			var certificate = new X509Certificate2(settings.Https.CertificatePath, settings.Https.CertificatePassword);
			configureAction(443, certificate);
		}
		configureAction(80, null);
	}
});

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

var options = new RewriteOptions()
	.Add(new RewriteLowercaseRule());
app.UseRewriter(options);

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();
app.MapControllerRoute(
	name: "object",
	pattern: "{controller=Object}/{action=Object}/{itemName}"
);
app.MapFallbackToController("{itemName}", "Object", "Object");
app.MapFallback(context => {
	context.Response.Redirect("/Pages/ErrorPage");
	return Task.CompletedTask;
});
app.Run();
