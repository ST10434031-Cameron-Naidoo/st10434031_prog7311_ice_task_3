using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Primary_And_High_School.Domain;

namespace Primary_High_School.DAL
{
    public class Primary_And_HighDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Student> Students {get; set;}

        public DbSet<Subject> Subjects { get; set; }

        public Primary_And_HighDbContext(DbContextOptions<Primary_And_HighDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s =>s.StudentNumber);

            modelBuilder.Entity<Subject>()
                .HasOne(su=>su.Student)
                .WithMany(su=>su.Subjects)
                .HasForeignKey(su=>su.StudentNumber);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Student)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.StudentNumber);
        }
    }
}
