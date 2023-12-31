﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace McDonaldoAPI.Model;

public partial class McDataBaseContext : DbContext
{
    public McDataBaseContext()
    {
    }

    public McDataBaseContext(DbContextOptions<McDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientOrder> ClientOrders { get; set; }

    public virtual DbSet<ClientOrderItem> ClientOrderItems { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YT\\SQLEXPRESS01;Initial Catalog=McDataBase;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientOr__3214EC2728AC93DC");

            entity.ToTable("ClientOrder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DeliveryMoment).HasColumnType("datetime");
            entity.Property(e => e.FinishMoment).HasColumnType("datetime");
            entity.Property(e => e.OrderCode)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.ClientOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientOrd__Store__3F466844");
        });

        modelBuilder.Entity<ClientOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientOr__3214EC27027CD117");

            entity.ToTable("ClientOrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientOrderId).HasColumnName("ClientOrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.ClientOrder).WithMany(p => p.ClientOrderItems)
                .HasForeignKey(d => d.ClientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientOrd__Clien__4222D4EF");

            entity.HasOne(d => d.Product).WithMany(p => p.ClientOrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientOrd__Produ__4316F928");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3214EC27071DA651");

            entity.ToTable("Menu");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.Product).WithMany(p => p.Menus)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu__ProductID__3B75D760");

            entity.HasOne(d => d.Store).WithMany(p => p.Menus)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu__StoreID__3C69FB99");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC271E88563D");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescriptionText)
                .IsRequired()
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Store__3214EC27F02C964E");

            entity.ToTable("Store");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Localization)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
