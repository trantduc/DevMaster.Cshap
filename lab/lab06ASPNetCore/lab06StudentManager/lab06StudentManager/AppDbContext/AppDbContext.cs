using lab06StudentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace lab06StudentManager
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<StdClass> StdClass { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Student> Student { get; set;  }
        public DbSet<Subjects> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // khai báo khóa chính của bảng
            modelBuilder.Entity<Marks>()
                .HasKey(x => new { x.SubjectId, x.StudentId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
