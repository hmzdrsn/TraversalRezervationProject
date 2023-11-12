using Microsoft.EntityFrameworkCore;

namespace SignalRApiSQL.DAL
{
	public class Context : DbContext
	{
		protected readonly IConfiguration _configuration;

		public Context(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
		}
		public DbSet<Visitor> Visitors { get; set; }
	}
}
