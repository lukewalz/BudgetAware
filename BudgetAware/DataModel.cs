namespace BudgetAware
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Budget> Budget { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Accounts>()
                .HasMany(e => e.Purchases)
                .WithRequired(e => e.Accounts)
                .HasForeignKey(e => e.Fk_AccountNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Budget)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.Fk_CategoriesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Purchases)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.Fk_CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Purchases>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Purchases>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.Fk_UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Budget)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.Fk_UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Budget>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);
        }
    }
}
