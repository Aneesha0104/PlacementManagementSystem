using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PMS.DAL.Models;

public partial class PmsdbContext : DbContext
{
    public PmsdbContext()
    {
    }

    public PmsdbContext(DbContextOptions<PmsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicDetail> AcademicDetails { get; set; }

    public virtual DbSet<College> Colleges { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Mail> Mail { get; set; }

    public virtual DbSet<PlacementAllocation> PlacementAllocations { get; set; }

    public virtual DbSet<PlacementDrive> PlacementDrives { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicDetail>(entity =>
        {
            entity.Property(e => e.AcademicDetailId).HasColumnName("AcademicDetailID");
            entity.Property(e => e.CollegeDegree)
                .HasMaxLength(50)
                .HasColumnName("College_degree");
            entity.Property(e => e.CollegePg)
                .HasMaxLength(50)
                .HasColumnName("college_pg");
            entity.Property(e => e.DegreePercentage).HasColumnName("Degree_percentage");
            entity.Property(e => e.PassOutYear10th)
                .HasColumnType("datetime")
                .HasColumnName("Pass_out_year_10th");
            entity.Property(e => e.PassOutYear12th)
                .HasColumnType("datetime")
                .HasColumnName("Pass_out_year_12th");
            entity.Property(e => e.PassOutYearDegree)
                .HasColumnType("datetime")
                .HasColumnName("Pass_out_year_Degree");
            entity.Property(e => e.PassOutYearPg)
                .HasColumnType("datetime")
                .HasColumnName("Pass_out_year_PG");
            entity.Property(e => e.Percentage12th).HasColumnName("Percentage_12th");
            entity.Property(e => e.PgPercentage).HasColumnName("PG_percentage");
            entity.Property(e => e.School10th)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("School_10th");
            entity.Property(e => e.School12th)
                .HasMaxLength(50)
                .HasColumnName("School_12th");
        });

        modelBuilder.Entity<College>(entity =>
        {
            entity.ToTable("College");

            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CollegeName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Colleges)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_College_Users");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CommentForOrg)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.CommentForStudent)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.PlacementAllocationId).HasColumnName("PlacementAllocationID");

            entity.HasOne(d => d.PlacementAllocation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PlacementAllocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_PlacementAllocation");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Branches).HasMaxLength(50);
            entity.Property(e => e.ContactNo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("contact_no");
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.EmailId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("emailID");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Website)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Companies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Companies_Users");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.College).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_College");
        });

        modelBuilder.Entity<Mail>(entity =>
        {
            entity.Property(e => e.MailId)
                .HasMaxLength(50)
                .HasColumnName("Mail_id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Flag).HasMaxLength(50);
            entity.Property(e => e.FromId)
                .HasMaxLength(50)
                .HasColumnName("from_id");
            entity.Property(e => e.Message).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.ToId)
                .HasMaxLength(50)
                .HasColumnName("to_id");
        });

        modelBuilder.Entity<PlacementAllocation>(entity =>
        {
            entity.HasKey(e => e.PlacementAllocationId).HasName("PK_JobApplications");

            entity.ToTable("PlacementAllocation");

            entity.Property(e => e.PlacementAllocationId).HasColumnName("PlacementAllocationID");
            entity.Property(e => e.CommentId)
                .HasMaxLength(50)
                .HasColumnName("CommentID");
            entity.Property(e => e.PlacementDriveId).HasColumnName("PlacementDriveID");
            entity.Property(e => e.PlacementStatus).HasComment("Scheduled, Passed , Failed");
            entity.Property(e => e.Rating).HasMaxLength(50);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.PlacementDrive).WithMany(p => p.PlacementAllocations)
                .HasForeignKey(d => d.PlacementDriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlacementAllocation_PlacementDrive");

            entity.HasOne(d => d.Student).WithMany(p => p.PlacementAllocations)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlacementAllocation_Students");
        });

        modelBuilder.Entity<PlacementDrive>(entity =>
        {
            entity.HasKey(e => e.PlacementDriveId).HasName("PK_InterviewDetails");

            entity.ToTable("PlacementDrive");

            entity.Property(e => e.PlacementDriveId).HasColumnName("PlacementDriveID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.Details)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.InterviewDate).HasColumnType("date");
            entity.Property(e => e.Package).HasMaxLength(50);
            entity.Property(e => e.Place)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.College).WithMany(p => p.PlacementDrives)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlacementDrive_College");

            entity.HasOne(d => d.Company).WithMany(p => p.PlacementDrives)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlacementDrive_Companies");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Students_1");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.AcademicDetailId).HasColumnName("AcademicDetailID");
            entity.Property(e => e.AcademicYear).HasMaxLength(30);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("EmailID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Hobbies).HasMaxLength(50);
            entity.Property(e => e.MaritalStatus).HasMaxLength(20);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.Mothertongue).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.NameOfGuardian).HasMaxLength(50);
            entity.Property(e => e.Occupation).HasMaxLength(50);
            entity.Property(e => e.Pin).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.RegisterNo).HasMaxLength(10);
            entity.Property(e => e.Remarks).HasMaxLength(50);
            entity.Property(e => e.Skills).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AcademicDetail).WithMany(p => p.Students)
                .HasForeignKey(d => d.AcademicDetailId)
                .HasConstraintName("FK_Students_AcademicDetails");

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Department");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
