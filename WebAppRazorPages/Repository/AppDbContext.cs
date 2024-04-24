using Microsoft.EntityFrameworkCore;
using System;
using WebAppRazorPages.Model;
using WebAppRazorPages.Model.AuthApp;

namespace WebAppRazorPages.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Samolet>? Samolet { get; set; }
        public DbSet<AuthUser>? AuthSamolet { get; set; }
        public DbSet<SubjectGrade>? SubjectGrades { get; set; }
        public DbSet<Subject>? Subjects { get; set; }

    }
}
