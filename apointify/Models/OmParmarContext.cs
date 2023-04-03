using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using apointify.VirtualModels;

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

    public virtual DbSet<ApproxNumber> ApproxNumbers { get; set; }

    public virtual DbSet<ClientComunnication> ClientComunnications { get; set; }

    public virtual DbSet<CompanyTable> CompanyTables { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DatabaseImageTable> DatabaseImageTables { get; set; }

    public virtual DbSet<DateAndTime> DateAndTimes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<StocksTable> StocksTables { get; set; }

    public virtual DbSet<TotalOrder> TotalOrders { get; set; }

    public virtual DbSet<TransactionsTable> TransactionsTables { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UsersTable> UsersTables { get; set; }

    public virtual DbSet<WatchlistTable> WatchlistTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.33;Initial Catalog=Om Parmar;Persist Security Info=False;User ID=trainee;Password=Admin@123;MultipleActiveResultSets=False;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

    public DbSet<apointify.VirtualModels.EmployeeVM> EmployeeVM { get; set; } = default!;
}
