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

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<ApproxNumber> ApproxNumbers { get; set; }

    public virtual DbSet<ClientComunnication> ClientComunnications { get; set; }

    public virtual DbSet<CompanyTable> CompanyTables { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DatabaseImageTable> DatabaseImageTables { get; set; }

    public virtual DbSet<DateAndTime> DateAndTimes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Img> Imgs { get; set; }

    public virtual DbSet<NewAppointment> NewAppointments { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceP> ServicePs { get; set; }

    public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }

    public virtual DbSet<StocksTable> StocksTables { get; set; }

    public virtual DbSet<TotalOrder> TotalOrders { get; set; }

    public virtual DbSet<TransactionsTable> TransactionsTables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UsersTable> UsersTables { get; set; }

    public virtual DbSet<WatchlistTable> WatchlistTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.33;Initial Catalog=Om Parmar;Persist Security Info=False;User ID=trainee;Password=Admin@123;MultipleActiveResultSets=False;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.ApointmentId).HasName("PK__Appointm__773D928C92AE6B42");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment Date");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FirmNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Firm)
                .HasConstraintName("FK__Appointme__FirmI__5E8A0973");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK__Appointme__UserI__5F7E2DAC");
        });

        modelBuilder.Entity<ApproxNumber>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("approxNumber");
        });

        modelBuilder.Entity<ClientComunnication>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("clientComunnication");

            entity.Property(e => e.ClientFeedback)
                .HasColumnType("ntext")
                .HasColumnName("clientFeedback");
            entity.Property(e => e.ClientName)
                .HasMaxLength(20)
                .HasColumnName("clientName");
        });

        modelBuilder.Entity<CompanyTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company___3213E83F922AA8CD");

            entity.ToTable("Company_Table");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Exchange)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("exchange");
            entity.Property(e => e.Industry)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("industry");
            entity.Property(e => e.Name)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sector)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("sector");
            entity.Property(e => e.Symbol)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8392531C3");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserEmailAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DatabaseImageTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DatabaseImageTable");

            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ImageName)
                .HasMaxLength(100)
                .HasColumnName("image name");
        });

        modelBuilder.Entity<DateAndTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dateAndTime");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("dateTime");
            entity.Property(e => e.DateTime2).HasColumnName("dateTime2");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FE6374423");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Id, "Test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Department)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Name)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F111C919D6A");

            entity.ToTable("Employees");

            entity.HasIndex(e => e.UserEmailAddress, "UQ__Employee__0E75286E1ECBF559").IsUnique();

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserEmailAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("feedback");

            entity.Property(e => e.Feedback1)
                .HasColumnType("text")
                .HasColumnName("Feedback");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Image__7516F70C1E26D0BC");

            entity.ToTable("Image");

            entity.Property(e => e.ImageName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Img>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("img");

            entity.Property(e => e.ImgId)
                .ValueGeneratedOnAdd()
                .HasColumnName("imgId");
            entity.Property(e => e.Imgpath)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imgpath");
        });

        modelBuilder.Entity<NewAppointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("newAppointment");

            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment Date");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirmName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm Name");
            entity.Property(e => e.FirmOwnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm OwnerName");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ServiceProviderCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ServiceProvider_City");
            entity.Property(e => e.ServiceProviderEmail)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ServiceProviderMobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ServiceProvider_MobileNumber");
            entity.Property(e => e.ServiceProviderUsername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ServiceProvider_Username");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("serviceType");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF12F39C54");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.Shippingdate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__73BA3083");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Orders__Employee__74AE54BC");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderdetailsId).HasName("PK__Orderdet__3D263491736734B3");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("FinalAMount");
            entity.Property(e => e.InsertedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.ItemName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Orderdeta__Order__787EE5A0");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__CD98462AB16E3F69");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__4550733F3FD13F5D");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceP>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ServiceP");

            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirmName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm Name");
            entity.Property(e => e.FirmOwnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm OwnerName");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("serviceType");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceProvider>(entity =>
        {
            entity.HasKey(e => e.FirmId).HasName("PK__ServiceP__1F1F209CA9421BEE");

            entity.ToTable("ServiceProvider");

            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirmName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm Name");
            entity.Property(e => e.FirmOwnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firm OwnerName");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("serviceType");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceProviders)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServicePr__servi__58D1301D");
        });

        modelBuilder.Entity<StocksTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stocks_T__3213E83FEDA456EB");

            entity.ToTable("Stocks_Table");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Company).WithMany(p => p.StocksTables)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Stocks_Ta__compa__0F624AF8");
        });

        modelBuilder.Entity<TotalOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Total_order");

            entity.Property(e => e.Firstname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HavingTotalOrder).HasColumnName("having total order");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("Total Amount");
        });

        modelBuilder.Entity<TransactionsTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC075FFF4E3C");

            entity.ToTable("Transactions_Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StockId).HasColumnName("Stock_id");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .HasColumnName("Transaction_type");

            entity.HasOne(d => d.Stock).WithMany(p => p.TransactionsTables)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__Transacti__Stock__1DB06A4F");
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

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userInfo");

            entity.Property(e => e.Fees).HasColumnType("money");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PassFail).HasColumnName("Pass/Fail");
            entity.Property(e => e.Percentage).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserRole");

            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.InsertData).HasColumnType("datetime");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsersTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Ta__3213E83F34C79CE4");

            entity.ToTable("Users_Table");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<WatchlistTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Watchlis__3213E83FD39EB54E");

            entity.ToTable("Watchlist_Table");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.HasOne(d => d.Company).WithMany(p => p.WatchlistTables)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Watchlist__Compa__17F790F9");

            entity.HasOne(d => d.User).WithMany(p => p.WatchlistTables)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Watchlist__UserI__17036CC0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
