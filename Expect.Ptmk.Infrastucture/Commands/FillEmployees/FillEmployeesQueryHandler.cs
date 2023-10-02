using Expect.Ptmk.Data.Interfaces;
using Expect.Ptmk.Domain.Enums;
using Expect.Ptmk.Domain.Models;
using Expect.Ptmk.Infrastucture.Common.Utils;
using MediatR;

namespace Expect.Ptmk.Infrastucture.Commands.FillEmployees
{
	public class FillEmployeesQueryHandler : IRequestHandler<FillEmployeesQuery>
	{
		private readonly IAppDbContext _context;
		private const int _employeeNumber = 1_000_000;
		private const int _specialEmployeeNumber = 100;

		public FillEmployeesQueryHandler(IAppDbContext context)
		{
			_context = context;
		}

		//Default insert
		//Elapsed time: 00:01:40.3865876
		//public async Task Handle(FillEmployeesQuery request, CancellationToken cancellationToken)
		//{
		//	for(var i  = 0; i < _employeeNumber; i++)
		//	{
		//		var employee = new Employee
		//		{
		//			Id = Guid.NewGuid(),
		//			FullName = RandomGenerator.GetRandomName(10),
		//			DateOfBirth = RandomGenerator.GetRandomDateOfBirth(),
		//			Gender = RandomGenerator.GetRandomGender(),
		//		};

		//		await _context.Employees.AddAsync(employee, cancellationToken);
		//	}

		//	for(var i = 0; i < _specialEmployeeNumber; i++)
		//	{
		//		var employee = new Employee
		//		{
		//			Id = Guid.NewGuid(),
		//			FullName = "F" + RandomGenerator.GetRandomName(10),
		//			DateOfBirth = RandomGenerator.GetRandomDateOfBirth(),
		//			Gender = Gender.Male,
		//		};

		//		await _context.Employees.AddAsync(employee, cancellationToken);
		//	}

		//	await _context.SaveChangesAsync(cancellationToken);
		//}

		//Bulk Insert = 1000
		//Elapsed time: 00:00:35.7184647
		public async Task Handle(FillEmployeesQuery request, CancellationToken cancellationToken)
		{
			var employees = new List<Employee>();
			var specialEmployees = new List<Employee>();

			for (var i = 0; i < _employeeNumber; i++)
			{
				var employee = new Employee
				{
					Id = Guid.NewGuid(),
					FullName = RandomGenerator.GetRandomName(10),
					DateOfBirth = RandomGenerator.GetRandomDateOfBirth(),
					Gender = RandomGenerator.GetRandomGender(),
				};

				employees.Add(employee);
			}

			for (var i = 0; i < _specialEmployeeNumber; i++)
			{
				var employee = new Employee
				{
					Id = Guid.NewGuid(),
					FullName = "F" + RandomGenerator.GetRandomName(10),
					DateOfBirth = RandomGenerator.GetRandomDateOfBirth(),
					Gender = Gender.Male,
				};

				specialEmployees.Add(employee);
			}

			await _context.Employees.BulkInsertAsync(employees, options => options.BatchSize = 1000, cancellationToken);
			await _context.Employees.BulkInsertAsync(specialEmployees, options => options.BatchSize = 1000, cancellationToken);
		}
	}
}
