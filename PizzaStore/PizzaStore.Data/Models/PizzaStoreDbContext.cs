using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Data.Models
{
    public partial class PizzaStoreDbContext : DbContext
    {
        public PizzaStoreDbContext()
        {
        }

        public PizzaStoreDbContext(DbContextOptions<PizzaStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationIngredient> LocationIngredient { get; set; }
        public virtual DbSet<LocationUser> LocationUser { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredient { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=garydotnet2019.database.windows.net;database=PizzaStoreDB;user id=sqladmin;password=Florida2019;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient", "PizzaStore");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "PizzaStore");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<LocationIngredient>(entity =>
            {
                entity.HasKey(e => e.LocationIngredient1)
                    .HasName("PK__Location__96BA32B9BB7419B7");

                entity.ToTable("LocationIngredient", "PizzaStore");

                entity.Property(e => e.LocationIngredient1).HasColumnName("LocationIngredient");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.InventoryAmount).HasDefaultValueSql("((20))");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.LocationIngredient)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK__LocationI__Ingre__6383C8BA");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationIngredient)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__LocationI__Locat__628FA481");
            });

            modelBuilder.Entity<LocationUser>(entity =>
            {
                entity.ToTable("LocationUser", "PizzaStore");

                entity.Property(e => e.LocationUserId).HasColumnName("LocationUserID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationUser)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__LocationU__Locat__5EBF139D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LocationUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LocationU__UserI__5FB337D6");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "PizzaStore");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(4, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime2(0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Voidable).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Order__StoreID__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Order__UserID__5441852A");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PizzaStore");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(4, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasDefaultValueSql("((10))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Pizza__OrderId__59FA5E80");
            });

            modelBuilder.Entity<PizzaIngredient>(entity =>
            {
                entity.ToTable("PizzaIngredient", "PizzaStore");

                entity.Property(e => e.PizzaIngredientId).HasColumnName("PizzaIngredientID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzaIngredient)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK__PizzaIngr__Ingre__68487DD7");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredient)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__PizzaIngr__Pizza__6754599E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "PizzaStore");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });
        }
    }
}
