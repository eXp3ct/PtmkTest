using Expect.Ptmk.Domain.Enums;
using MediatR;

namespace Expect.Ptmk.Infrastucture.Commands.AddEmployee
{
	public class AddEmployeeQuery : IRequest
	{
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Gender Gender { get; set; }

		public AddEmployeeQuery(string fullName, DateTime dateOfBirth, Gender gender)
		{
			FullName = fullName;
			DateOfBirth = dateOfBirth;
			Gender = gender;
		}
	}
}
