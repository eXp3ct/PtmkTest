using Expect.Ptmk.Data.Interfaces;
using Expect.Ptmk.Domain.Models;
using MediatR;

namespace Expect.Ptmk.Infrastucture.Commands.AddEmployee
{
	public class AddEmployeeQueryHandler : IRequestHandler<AddEmployeeQuery>
	{
		private readonly IAppDbContext _context;

		public AddEmployeeQueryHandler(IAppDbContext context)
		{
			_context = context;
		}

		public async Task Handle(AddEmployeeQuery request, CancellationToken cancellationToken)
		{
			var employee = new Employee
			{
				Id = Guid.NewGuid(),
				FullName = request.FullName,
				DateOfBirth = request.DateOfBirth,
				Gender = request.Gender
			};

			await _context.Employees.AddAsync(employee, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
