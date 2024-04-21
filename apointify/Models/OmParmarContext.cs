using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apointify.Models;

public partial class OmParmarContext : DbContext
{
    public OmParmarContext()
    {
    }

    public OmParmarContext(DbContextOptions<OmParmarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allappointment> Allappointments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<FirmDetail> FirmDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=mr1272\\MSSQLSERVER2;Database=Om Parmar;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allappointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("allappointment");

            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment Date");
            entity.Property(e => e.BookingInstructions)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bookingInstructions");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirmAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("firmAddress");
            entity.Property(e => e.FirmEmail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("firmEmail");
            entity.Property(e => e.FirmMobile)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("firmMobile");
            entity.Property(e => e.FirmName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("firmName");
            entity.Property(e => e.TimeSlot).HasPrecision(2);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserMobile)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("userMobile");
            entity.Property(e => e.Usersname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usersname");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC25C8E095E");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment Date");
            entity.Property(e => e.BookingInstructions)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bookingInstructions");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.TimeSlot).HasPrecision(2);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Firm).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK__Appointme__FirmI__395884C4");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Appointme__UserI__3A4CA8FD");
        });

        modelBuilder.Entity<FirmDetail>(entity =>
        {
            entity.HasKey(e => e.FirmId).HasName("PK__FirmDeta__1F1F209C3072BC1F");

            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.FirmImage)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirmName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Firm Name");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.ServiceType)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("serviceType");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A29A58091");

            entity.ToTable("Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__4550733F79492800");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Img)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C2AC9CB3A");

            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.InsertData)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Role");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("User_Role");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Mobile no.");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
