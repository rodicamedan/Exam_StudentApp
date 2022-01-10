using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.Models;
namespace StudentApp.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) :
base(options)
        {
        }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        public DbSet<Specializare> Specializari { get; set; }
        public DbSet<SpecializareStudenti> SpecilizariStudenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Profesor>().ToTable("Profesor");
            modelBuilder.Entity<Curs>().ToTable("Curs");
            modelBuilder.Entity<Specializare>().ToTable("Specializare");
            modelBuilder.Entity<SpecializareStudenti>().ToTable("SpecializareStudenti");
            modelBuilder.Entity<SpecializareStudenti>()
            .HasKey(c => new { c.StudentID, c.SpecializareID });//configureaza cheia         primara compusa

        }
    }
}
