using Expect.Ptmk.Data;
using Expect.Ptmk.Infrastucture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expect.Ptmk.Main
{
	public static class Startup
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddPersistance(configuration);
			services.AddInfrastucture();
		}
	}
}
