using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace University.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<DepartmentLesson>().HasKey(q =>
        //    new
        //    {
        //        q.LessonId,
        //        q.DepartmentId
        //    });

        //    builder.Entity<DepartmentLesson>().HasOne(q => q.Lesson).WithMany(y => y.DepartmentLessons).HasForeignKey(t => t.LessonId);
        //    builder.Entity<DepartmentLesson>().HasOne(q => q.Department).WithMany(y => y.DepartmentLessons).HasForeignKey(t => t.DepartmentId);
        //}
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentLesson> DepartmentLessons { get; set; }
        public DbSet<DepartmentFee> DepartmentFee { get; set; }

        public DbSet<StudentLesson> StudentLessons { get; set; }
    }
}