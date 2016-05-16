using System.Data.Entity;

using DataAccessLayer.Entities;
using DataAccessLayer.IdentityEntities;

using Microsoft.AspNet.Identity.EntityFramework;


namespace DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCategory> StudentCategories { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public AppDbContext() : base()
        {
            Database.SetInitializer(
            new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>());
        }
    }
}
