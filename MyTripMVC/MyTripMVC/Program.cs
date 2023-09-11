using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTripMVC.Models;

namespace MyTripMVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			builder.Services.AddTransient<DataService>();

			// Hämta connection-strängen från AppSettings.json
			var connString = builder.Configuration.GetConnectionString("DefaultConnection");
			// Registrera Context-klassen för dependency injection
			builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationContext>()
			.AddDefaultTokenProviders();
			// 2. Specificera att cookies ska användas och URL till inloggnings-sidan
			builder.Services.ConfigureApplicationCookie(
			o => o.LoginPath = "/login");
			var app = builder.Build();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			if (!app.Environment.IsDevelopment())
			{
				app.UseStatusCodePagesWithRedirects("/error/http/{0}");
				app.UseExceptionHandler("/error/exception");
			}

			app.UseRouting();
			app.UseAuthorization(); // 3. Behörighet
			app.UseEndpoints(o => o.MapControllers());

			app.Run();
		}
	}
}