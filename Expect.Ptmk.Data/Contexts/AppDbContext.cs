using Expect.Ptmk.Data.Interfaces;
using Expect.Ptmk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Expect.Ptmk.Data.Contexts
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
