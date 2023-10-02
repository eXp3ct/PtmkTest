using Expect.Ptmk.Data.Contexts;
using Expect.Ptmk.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expect.Ptmk.Data
{
	public static class DependencyInjection
	{
		public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = "Host=localhost;Port=5432;Database=root;Username=root;Password=root;";
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});

			services.AddScoped<IAppDbContext, AppDbContext>();
		}
	}
}
