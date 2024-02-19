using Microsoft.EntityFrameworkCore;

namespace FitnessApplikation
{
    public class FitnessDbContext : DbContext
    {
        public DbSet<Trainingsplan> Trainingsplaene { get; set; }
        public DbSet<Uebungen> Uebungen { get; set; }

        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainingsplan>().HasKey(tp => tp.TrainingsplanID);
            modelBuilder.Entity<Uebungen>().HasKey(u => u.UebungID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TrainingsplanDb;Trusted_Connection=True");
        }
    }
}
