using Expect.Ptmk.Data.Interfaces;
using Expect.Ptmk.Domain.Enums;
using Expect.Ptmk.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expect.Ptmk.Infrastucture.Commands.SelectEmployees
{
	public class SelectEmployeesQueryHandler : IRequestHandler<SelectEmployeesQuery, IEnumerable<Employee>>
	{
		private readonly IAppDbContext _context;

		public SelectEmployeesQueryHandler(IAppDbContext context)
		{
			_context = context;
		}

		//Default select
		//Elapsed time: 00:00:01.1983453
		public async Task<IEnumerable<Employee>> Handle(SelectEmployeesQuery request, CancellationToken cancellationToken)
		{
			var list = await _context.Employees
										.Where(x => x.Gender == Gender.Male && x.FullName.StartsWith("f"))
										.ToListAsync(cancellationToken);

			return list;
		}

		//Bulk read
		//public async Task<IEnumerable<Employee>> Handle(SelectEmployeesQuery request, CancellationToken cancellationToken)
		//{
		//	var list = await _context.Employees
		//									.Where(x => x.Gender == Gender.Male && x.FullName.StartsWith("f"))
		//									.WhereBulkContains(x => x.);

		//	return list;
		//}
	}
}
