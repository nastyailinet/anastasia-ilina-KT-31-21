using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Models;
using AnastasiaIlinaKT_31_21.Database.Configurations;

namespace AnastasiaIlinaKT_31_21.Database
{
    public class StudentDbContext : DbContext
    {
        DbSet<Student> Students { get; set; }

        DbSet<AcademicGroup> Groups { get; set; }

        DbSet<Discipline> Disciplines { get; set; }

        DbSet<Mark> Marks { get; set; }

        DbSet<Test> Tests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}
