using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DimensionData.Models;

namespace DimensionData.Data
{
    public partial class DataDimensionContext : DbContext
    {
        public DataDimensionContext()
        {
        }

        public DataDimensionContext(DbContextOptions<DataDimensionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CostToCompany> CostToCompany { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }
        public virtual DbSet<EmployeeHistory> EmployeeHistory { get; set; }
        public virtual DbSet<EmployeePerformance> EmployeePerformance { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<JobInfo> JobInfo { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Surveys> Surveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Initial Catalog = DataDimension;Data Source=TSHIPHIWASAMBO;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CostToCompany>(entity =>
            {
                entity.HasKey(e => e.PayId);

                entity.Property(e => e.PayId)
                    .HasColumnName("PayID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PK_Employee_1");

                entity.Property(e => e.EmployeeNumber).ValueGeneratedNever();

                entity.Property(e => e.DetailsId).HasColumnName("DetailsID");

                entity.Property(e => e.EducationId).HasColumnName("EducationID");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.PayId).HasColumnName("PayID");

                entity.Property(e => e.PercentSalaryHike).HasMaxLength(50);

                entity.Property(e => e.SurveryId).HasColumnName("SurveryID");
            });

            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.Property(e => e.DetailsId)
                    .HasColumnName("DetailsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attrition).HasMaxLength(50);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.MaritalId).HasColumnName("MaritalID");

                entity.Property(e => e.Over18).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.Property(e => e.EducationId)
                    .HasColumnName("EducationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Education).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.HistoryId)
                    .HasColumnName("HistoryID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<EmployeePerformance>(entity =>
            {
                entity.HasKey(e => e.PerformanceId);

                entity.Property(e => e.PerformanceId)
                    .HasColumnName("PerformanceID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId)
                    .HasColumnName("GenderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gender1)
                    .HasColumnName("Gender")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<JobInfo>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.JobId)
                    .HasColumnName("JobID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.HasKey(e => e.MaritalId);

                entity.Property(e => e.MaritalId)
                    .HasColumnName("MaritalID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaritalStatus1).HasColumnName("MaritalStatus");
            });

            modelBuilder.Entity<Surveys>(entity =>
            {
                entity.HasKey(e => e.SurveyId);

                entity.Property(e => e.SurveyId)
                    .HasColumnName("SurveyID")
                    .ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
