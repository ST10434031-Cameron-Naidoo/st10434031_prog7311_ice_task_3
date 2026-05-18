using Microsoft.EntityFrameworkCore;
using Primary_And_High_School.Domain;
using System.Reflection.Emit;

namespace Primary_High_School.DAL
{
    public class Primary_And_HighDbContext : DbContext
    {
        public Primary_And_HighDbContext(DbContextOptions<Primary_And_HighDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentNumber);

            // Student has many Subjects
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Subjects)
                .HasForeignKey(s => s.StudentNumber);

            // Subject has many Books
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Subject)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.SubjectId);
        }
    }
}