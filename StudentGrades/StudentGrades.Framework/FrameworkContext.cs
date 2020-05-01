using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGrades.Framework
{
    public class FrameworkContext : DbContext
    {
        private string _connectionStringName;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionStringName = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionStringName, m => m.MigrationsAssembly(_migrationAssemblyName));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentGrade>()
                .HasKey(sg => new { sg.StudentId, sg.SubjectId });

            modelBuilder.Entity<StudentGrade>()
                .HasOne(sg => sg.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(sg => sg.StudentId);

            modelBuilder.Entity<StudentGrade>()
                .HasOne(sg => sg.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(sg => sg.SubjectId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
