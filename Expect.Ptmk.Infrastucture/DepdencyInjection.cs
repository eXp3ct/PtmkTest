using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Expect.Ptmk.Infrastucture
{
	public static class DepdencyInjection
	{
		public static void AddInfrastucture(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
		}
	}
}