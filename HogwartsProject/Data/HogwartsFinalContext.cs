using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HogwartsProject.Models;

namespace HogwartsProject.Data
{
    public partial class HogwartsFinalContext : DbContext
    {
        public HogwartsFinalContext()
        {
        }

        public HogwartsFinalContext(DbContextOptions<HogwartsFinalContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<TakingSubject> TakingSubjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WorkInDept> WorkInDepts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-6LJDH4RT; Initial Catalog=HogwartsFinal; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.AdminUserId)
                    .HasName("PK_AdminUser");

                entity.Property(e => e.AdminUserId).HasColumnName("AdminUserID");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeID");

                entity.Property(e => e.Pword).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.AdminUsers)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_AdminUser_Employee");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Classes");

                entity.Property(e => e.ClassName).HasMaxLength(30);

                entity.Property(e => e.ClassYear).HasMaxLength(20);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("Departments");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(30);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DateOfEmployment).HasColumnType("date");

                entity.Property(e => e.FkRoleId).HasColumnName("FK_RoleID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.PersonalNumber).HasMaxLength(15);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.FkRole)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.FkRoleId)
                    .HasConstraintName("FK_Employee_Roles");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grades");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Grade1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Grade")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(25);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassID");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_Students_Classes");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subjects");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeID");

                entity.Property(e => e.SubjectDifficulty).HasMaxLength(30);

                entity.Property(e => e.SubjectName).HasMaxLength(30);

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_Subject_Employee");
            });

            modelBuilder.Entity<TakingSubject>(entity =>
            {
                entity.HasKey(e => e.TakeSubjectId)
                    .HasName("PK_TakingSubjects");

                entity.ToTable("TakingSubjects");

                entity.Property(e => e.TakeSubjectId).HasColumnName("TakeSubjectID");

                entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeID");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentID");

                entity.Property(e => e.FkSubjectId).HasColumnName("FK_SubjectID");

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.HasOne(d => d.FkGrade)
                    .WithMany(p => p.TakingSubjects)
                    .HasForeignKey(d => d.FkGradeId)
                    .HasConstraintName("FK_TakingSubjects_Grades");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.TakingSubjects)
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_TakingSubjects_Students");

                entity.HasOne(d => d.FkSubject)
                    .WithMany(p => p.TakingSubjects)
                    .HasForeignKey(d => d.FkSubjectId)
                    .HasConstraintName("FK_TakingSubjects_Subjects");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeID");

                entity.Property(e => e.Pword).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_AdminUser_Employee");
            });

            modelBuilder.Entity<WorkInDept>(entity =>
            {
                entity.Property(e => e.WorkInDeptId).HasColumnName("WorkInDeptID");

                entity.Property(e => e.FkDepartmentId).HasColumnName("FK_DepartmentID");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeID");

                entity.Property(e => e.FkRoleId).HasColumnName("FK_RoleID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
