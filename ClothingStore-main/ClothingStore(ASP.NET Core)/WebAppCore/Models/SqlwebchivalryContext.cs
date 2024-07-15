using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppCore.Models;

public partial class SqlwebchivalryContext : DbContext
{
    public SqlwebchivalryContext()
    {
    }

    public SqlwebchivalryContext(DbContextOptions<SqlwebchivalryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<AttributesPrice> AttributesPrices { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<TransactStatus> TransactStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=WebAppCore;User Id=sa;Password=Password.1;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5868862000F");

            entity.HasIndex(e => e.Phone, "UQ__Accounts__5C7E359E95E5A526").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Accounts__A9D1053421F78C2B").IsUnique();

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PassWord).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Salt)
                .HasMaxLength(10)
                .IsFixedLength();
        });
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Blogs__DD37D91AC114EFE7");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("PostID");

            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Scontents).HasMaxLength(255);
            entity.Property(e => e.Contents).HasMaxLength(255);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Alias).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.MetaKey).HasMaxLength(255);
            entity.Property(e => e.MetaDesc).HasMaxLength(255);

        });
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__Attribut__C189298A1DD6ED7E");

            entity.Property(e => e.AttributeId)
                .ValueGeneratedNever()
                .HasColumnName("AttributeID");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<AttributesPrice>(entity =>
        {
            entity.HasKey(e => e.AttributesPricesId).HasName("PK__Attribut__5AD74131593DAFC3");

            entity.ToTable("AttributesPrice");

            entity.Property(e => e.AttributesPricesId)
                .ValueGeneratedNever()
                .HasColumnName("AttributesPricesID");
            entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__6A1C8ADA2C1771E6");

            entity.Property(e => e.CatId)
                .ValueGeneratedNever()
                .HasColumnName("CatID");
            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CatName).HasMaxLength(250);
            entity.Property(e => e.Cover).HasMaxLength(250);
            entity.Property(e => e.MetaDesc).HasMaxLength(250);
            entity.Property(e => e.MetaKey).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.Thumb).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B88C7E2AD9");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359EBCFCA91B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534D606710F").IsUnique();

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsFixedLength();
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA47797FEA44D");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameWithType).HasMaxLength(255);
            entity.Property(e => e.PathWithType).HasMaxLength(255);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF1148E79E");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30CB57518EB");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_Orders");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PK__Pages__C565B124FFAE473E");

            entity.Property(e => e.PageId)
                .ValueGeneratedNever()
                .HasColumnName("PageID");
            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.MetaDesc).HasMaxLength(250);
            entity.Property(e => e.MetaKey).HasMaxLength(250);
            entity.Property(e => e.PageName).HasMaxLength(250);
            entity.Property(e => e.Thumb).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED2D4C1383");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Alias).HasMaxLength(255);
            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModDified).HasColumnType("datetime");
            entity.Property(e => e.Images).HasMaxLength(255);
            entity.Property(e => e.MetaDesc).HasMaxLength(255);
            entity.Property(e => e.MetaKey).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ShortDesc).HasMaxLength(255);
            entity.Property(e => e.Thumb).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A15033794");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TransactStatus>(entity =>
        {
            entity.HasKey(e => e.TransactStatusId).HasName("PK__Transact__C8BCD276663C8474");

            entity.ToTable("TransactStatus");

            entity.Property(e => e.TransactStatusId)
                .ValueGeneratedNever()
                .HasColumnName("TransactStatusID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
