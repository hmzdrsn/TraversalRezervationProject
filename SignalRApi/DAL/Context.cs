using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
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
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));//db baglanti
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
