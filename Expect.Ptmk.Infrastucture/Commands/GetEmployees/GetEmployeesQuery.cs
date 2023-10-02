using Expect.Ptmk.Domain.Models;
using MediatR;

namespace Expect.Ptmk.Infrastucture.Commands.GetEmployees
{
	public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
	{

	}
}
