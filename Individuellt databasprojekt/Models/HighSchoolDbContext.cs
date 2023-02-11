using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class HighSchoolDbContext : DbContext
    {
        public HighSchoolDbContext()
        {
        }

        public HighSchoolDbContext(DbContextOptions<HighSchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<ImportanStudentInfo> ImportanStudentInfo { get; set; }
        public virtual DbSet<Proffesion> Proffesion { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = KENNYLINDBLOM;Initial Catalog=HighSchoolDb;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DateOfHired).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ProffesionId).HasColumnName("ProffesionID");

                entity.Property(e => e.Salary).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.Proffesion)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ProffesionId)
                    .HasConstraintName("FK_Employee_Proffesion");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName).HasMaxLength(50);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.DateOfGrade).HasColumnType("date");

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.Grade1).HasColumnName("Grade");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.EmployerId)
                    .HasConstraintName("FK_Grade_Employee");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Grade_Student ");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Grade_Subject");
            });

            modelBuilder.Entity<ImportanStudentInfo>(entity =>
            {
                entity.HasKey(e => e.InfoId);

                entity.ToTable("importanStudentInfo");

                entity.Property(e => e.InfoId).HasColumnName("infoID");

                entity.Property(e => e.Info).HasMaxLength(100);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ImportanStudentInfo)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_importanStudentInfo_Student ");
            });

            modelBuilder.Entity<Proffesion>(entity =>
            {
                entity.HasKey(e => e.ProffessionId);

                entity.Property(e => e.ProffessionId).HasColumnName("ProffessionID");

                entity.Property(e => e.ProffessionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student ");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PersonNumber).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Student _Class");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Student _Gender");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
