using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NaturalFlowers.Models;
using NaturalFlowersBlazor.Data.Migrations;

namespace NaturalFlowersBlazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bundle> Bundles { get; set; } = null!;
        public virtual DbSet<BundleItem> BundleItems { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-LUFO56M;Database=NaturalFlowers;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server = tcp:naturalflowersdbserver.database.windows.net,1433; Initial Catalog = NaturalFlowers_db; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; Authentication = \"Active Directory Default\";"); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.ToTable("Bundle");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<BundleItem>(entity =>
            {
                entity.ToTable("BundleItem");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Bundle)
                    .WithMany(p => p.BundleItems)
                    .HasForeignKey(d => d.BundleId)
                    .HasConstraintName("FK_bundleItem_bundle");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.BundleItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_bundleItem_item");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.HasOne(d => d.Bundle)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BundleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_bundle");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_user");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Item");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BillCountry).HasMaxLength(50);

                entity.Property(e => e.BillPostalCode).HasMaxLength(50);

                entity.Property(e => e.BusinessAddress).HasMaxLength(50);

                entity.Property(e => e.BusinessDeliveryAddress).HasMaxLength(50);

                entity.Property(e => e.BusinessName).HasMaxLength(50);

                entity.Property(e => e.BusinessPhone).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        protected void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}