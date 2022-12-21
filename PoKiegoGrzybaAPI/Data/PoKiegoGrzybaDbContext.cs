using Microsoft.EntityFrameworkCore;
using PoKiegoGrzybaAPI.Models;

namespace PoKiegoGrzybaAPI.Data
{
    public class PoKiegoGrzybaDbContext:DbContext
    {
        public PoKiegoGrzybaDbContext(DbContextOptions<PoKiegoGrzybaDbContext> options) :base(options)
        {

        }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Badge> Badge { get; set; }
        public DbSet<Mushroom> Mushroom { get; set; }
        public DbSet<MushroomHunter> MushroomHunter { get; set; }
        public DbSet<MushroomSpot> MushroomSpot { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
