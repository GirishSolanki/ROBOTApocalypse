using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ROBOTApocalypse.Entity;

namespace ROBOTApocalypse.DB
{
    public class ROBOTApocalypseDBContext : DbContext
    {
        public ROBOTApocalypseDBContext(DbContextOptions<ROBOTApocalypseDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Survivors> Survivors { get; set; }
        public virtual DbSet<SurvivorLocation> SurvivorLocation { get; set; }
    }

    public class ROBOTApocalypseContextFactory : IDesignTimeDbContextFactory<ROBOTApocalypseDBContext>
    {
        public ROBOTApocalypseDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ROBOTApocalypseDBContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CS2S3QF;Initial Catalog=ROBOTApocalypse;Integrated Security=True");

            return new ROBOTApocalypseDBContext(optionsBuilder.Options);
        }
    }
}
