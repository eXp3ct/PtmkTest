using Expect.Ptmk.Domain.Enums;
using Expect.Ptmk.Domain.Interfaces;

namespace Expect.Ptmk.Domain.Models
{
	public class Employee : IHaveId
	{
		public Guid Id { get; set; }
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Gender Gender { get; set; }

		public int GetAge()
		{
			var today = DateTime.Today;

			var age = today.Year - DateOfBirth.Year;

			if (DateOfBirth.Date > today.AddYears(-age)) age--;

			return age;
		}
	}
}
