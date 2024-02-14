using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class InstituteManagementSystemContext : DbContext
    {
        public InstituteManagementSystemContext()
        {
        }

        public InstituteManagementSystemContext(DbContextOptions<InstituteManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batch> Batches { get; set; } = null!;
        public virtual DbSet<BillWisePaymentDetail> BillWisePaymentDetails { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CoursesJoined> CoursesJoineds { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<PaymentMode> PaymentModes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentBill> StudentBills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=HGT-DSK-076;Database=InstituteManagementSystem;user id=sa;password=Hallmark123;encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch");

                entity.Property(e => e.BatchName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Timings)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Batch__CourseId__300424B4");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK__Batch__FacultyId__30F848ED");
            });

            modelBuilder.Entity<BillWisePaymentDetail>(entity =>
            {
                entity.HasKey(e => e.PaymentDetailId)
                    .HasName("PK__BillWise__7F4E340FC0EBC6CD");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.BillWisePaymentDetails)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__BillWiseP__Cours__403A8C7D");

                entity.HasOne(d => d.PaymentMode)
                    .WithMany(p => p.BillWisePaymentDetails)
                    .HasForeignKey(d => d.PaymentModeId)
                    .HasConstraintName("FK__BillWiseP__Payme__412EB0B6");

                entity.HasOne(d => d.StudentBill)
                    .WithMany(p => p.BillWisePaymentDetails)
                    .HasForeignKey(d => d.StudentBillId)
                    .HasConstraintName("FK__BillWiseP__Stude__3E52440B");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BillWisePaymentDetails)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__BillWiseP__Stude__3F466844");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseContent)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CourseDuration).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CourseFee).HasColumnType("money");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CourseType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CoursesJoined>(entity =>
            {
                entity.ToTable("CoursesJoined");

                entity.Property(e => e.CourseFee).HasColumnType("money");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesJoineds)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__CoursesJo__Cours__34C8D9D1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CoursesJoineds)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__CoursesJo__Stude__33D4B598");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YearsOfExperience).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.ToTable("PaymentMode");

                entity.Property(e => e.PaymentModeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfRegistration)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StateName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentBill>(entity =>
            {
                entity.Property(e => e.BillAmount).HasColumnType("money");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentBills)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__StudentBi__Cours__3A81B327");

                entity.HasOne(d => d.CoursesJoined)
                    .WithMany(p => p.StudentBills)
                    .HasForeignKey(d => d.CoursesJoinedId)
                    .HasConstraintName("FK__StudentBi__Cours__38996AB5");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentBills)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentBi__Stude__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
