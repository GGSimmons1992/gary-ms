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
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryIngredient> InventoryIngredient { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationUser> LocationUser { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderPizza> OrderPizza { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredient { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }

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

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "PizzaStore");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("InventoryID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<InventoryIngredient>(entity =>
            {
                entity.HasKey(e => e.InventoryIngredient1)
                    .HasName("PK__Inventor__12C1AFD30C6C7228");

                entity.ToTable("InventoryIngredient", "PizzaStore");

                entity.Property(e => e.InventoryIngredient1).HasColumnName("InventoryIngredient");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.InventoryIngredient)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK__Inventory__Ingre__6754599E");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryIngredient)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__Inventory__Inven__66603565");
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

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Sales)
                    .HasColumnType("numeric(9, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK__Location__Invent__5535A963");
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
                    .HasConstraintName("FK__LocationU__Locat__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LocationUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LocationU__UserI__6383C8BA");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "PizzaStore");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cost).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime2(0)");

                entity.Property(e => e.Voidable).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Order__StoreID__5AEE82B9");
            });

            modelBuilder.Entity<OrderPizza>(entity =>
            {
                entity.ToTable("OrderPizza", "PizzaStore");

                entity.Property(e => e.OrderPizzaId).HasColumnName("OrderPizzaID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderPizz__Order__6B24EA82");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__OrderPizz__Pizza__6A30C649");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PizzaStore");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Size).HasColumnName("size");
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
                    .HasConstraintName("FK__PizzaIngr__Ingre__6EF57B66");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredient)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__PizzaIngr__Pizza__6E01572D");
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

                entity.HasOne(d => d.LastVistNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.LastVist)
                    .HasConstraintName("FK__User__LastVist__5EBF139D");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(e => e.UserOrder1)
                    .HasName("PK__UserOrde__780A68F3E398FA91");

                entity.ToTable("UserOrder", "PizzaStore");

                entity.Property(e => e.UserOrder1).HasColumnName("UserOrder");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UserOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__UserOrder__Order__72C60C4A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrder)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserOrder__UserI__71D1E811");
            });
        }
    }
}
