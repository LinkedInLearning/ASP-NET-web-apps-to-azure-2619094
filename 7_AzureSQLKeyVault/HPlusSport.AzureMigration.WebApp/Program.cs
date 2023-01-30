using HPlusSport.AzureMigration.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ShopContext>(options =>
{
	if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
	{
		options.UseSqlServer(
			builder.Configuration.GetConnectionString("ShopContextProduction"));
	} else
	{
		options.UseSqlServer(
			builder.Configuration.GetConnectionString("ShopContext"));
	}
});

builder.Services.BuildServiceProvider().GetService<ShopContext>().Database.Migrate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
