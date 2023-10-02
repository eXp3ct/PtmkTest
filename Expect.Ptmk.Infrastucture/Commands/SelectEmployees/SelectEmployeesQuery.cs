using Expect.Ptmk.Domain.Models;
using MediatR;

namespace Expect.Ptmk.Infrastucture.Commands.SelectEmployees
{
	public class SelectEmployeesQuery : IRequest<IEnumerable<Employee>>
	{
	}
}
