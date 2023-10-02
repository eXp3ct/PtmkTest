using Expect.Ptmk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Expect.Ptmk.Data.Interfaces
{
	public interface IAppDbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
