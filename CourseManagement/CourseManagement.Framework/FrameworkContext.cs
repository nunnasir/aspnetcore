using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Framework
{
    public class FrameworkContext : DbContext, IFrameworkContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString, 
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Many to many relation
            builder.Entity<StudentRegistration>()
                .HasKey(sr => new { sr.StudentId, sr.CourseId });

            builder.Entity<StudentRegistration>()
                .HasOne(s => s.Student)
                .WithMany(c => c.StudentRegistrations)
                .HasForeignKey(s => s.StudentId);

            builder.Entity<StudentRegistration>()
                .HasOne(c => c.Course)
                .WithMany(c => c.StudentRegistrations)
                .HasForeignKey(s => s.CourseId);

            base.OnModelCreating(builder);
        }

        public DbSet<Course> Courses { get; set; }
    }
}
