using Expect.Ptmk.Data.Interfaces;
using Expect.Ptmk.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expect.Ptmk.Infrastucture.Commands.GetEmployees
{
	public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
	{
		private readonly IAppDbContext _context;

		public GetEmployeesQueryHandler(IAppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
		{
			var list = await _context.Employees.OrderBy(x => x.FullName).ToListAsync(cancellationToken);

			return list;
		}
	}
}
