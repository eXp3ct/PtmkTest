using ConsoleTables;
using Expect.Ptmk.Data.Contexts;
using Expect.Ptmk.Domain.Enums;
using Expect.Ptmk.Domain.Models;
using Expect.Ptmk.Infrastucture.Commands.AddEmployee;
using Expect.Ptmk.Infrastucture.Commands.FillEmployees;
using Expect.Ptmk.Infrastucture.Commands.GetEmployees;
using Expect.Ptmk.Infrastucture.Commands.SelectEmployees;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;

namespace Expect.Ptmk.Main
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder().Build();
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			using var scope = host.Services.CreateScope();
			var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
			host.Start();
			if (args[0] == "1")
			{
				var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				context.Database.Migrate();
			}
			else if (args[0] == "2")
			{
				var fullname = args[1];
				var birthDate = args[2];
				var gender = args[3];


				var query = new AddEmployeeQuery(fullname, DateTime.Parse(birthDate), Enum.Parse<Gender>(gender));
				await mediator.Send(query, CancellationToken.None);
			}
			else if (args[0] == "3")
			{
				var query = new GetEmployeesQuery();
				var list = await mediator.Send(query, CancellationToken.None);
				var table = new ConsoleTable(typeof(Employee).GetProperties().Select(x => x.Name).ToArray());

				foreach(var employee in list)
				{
					table.AddRow(employee.Id, employee.FullName, employee.DateOfBirth, employee.Gender);
				}

				table.Write();
			}
			else if (args[0] == "4")
			{
				var timer = new Stopwatch();
				var query = new FillEmployeesQuery();
				timer.Start();
				await mediator.Send(query, CancellationToken.None);
				timer.Stop();

                await Console.Out.WriteLineAsync($"Elapsed time: {timer.Elapsed}");
            }
			else if (args[0] == "5")
			{
				var timer = new Stopwatch();
				var query = new SelectEmployeesQuery();
				timer.Start();
				var list = await mediator.Send(query, CancellationToken.None);
				timer.Stop();
				var table = new ConsoleTable(typeof(Employee).GetProperties().Select(x => x.Name).ToArray());

				foreach (var employee in list)
				{
					table.AddRow(employee.Id, employee.FullName, employee.DateOfBirth, employee.Gender);
				}

				table.Write();
				await Console.Out.WriteLineAsync($"Elapsed time: {timer.Elapsed}");
			}
			await host.StopAsync();
		}

		private static IHostBuilder CreateHostBuilder() =>
			Host.CreateDefaultBuilder(null)
				.UseEnvironment("Development")
				.UseSerilog((context, config) =>
				{
					config
						.MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
						.WriteTo.Console(theme: AnsiConsoleTheme.Literate);
				})
				.ConfigureAppConfiguration((context, configBuilder) =>
				{
					configBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
				})
				.ConfigureServices((context, services) =>
				{
					services.ConfigureServices(context.Configuration);
				});
	}
}