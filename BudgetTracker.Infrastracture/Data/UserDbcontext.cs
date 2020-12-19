using BudgetTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Infrastracture.Data
{
   public class UserDbcontext : DbContext
    {
        public UserDbcontext(DbContextOptions<UserDbcontext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>(ConfigureUser);
            model.Entity<Income>(ConfigureIncome);
            model.Entity<Expenditure>(ConfigureExpenditure);
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Password).IsRequired().HasMaxLength(10);

            builder.Property(u => u.FullName).HasMaxLength(50);

            builder.Property(u => u.JoinedOn).HasDefaultValueSql("getdate()");
        }
        private void ConfigureIncome(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(In => In.Id);
            builder.Property(In => In.Amount).IsRequired().HasColumnType("money");
            builder.Property(In => In.Description).HasMaxLength(100);
            builder.Property(In => In.IncomeDate).HasDefaultValueSql("getdate()");
            builder.Property(In => In.Remarks).HasMaxLength(500);
        }
        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(Ex => Ex.Id);
            builder.Property(Ex => Ex.Amount).IsRequired().HasColumnType("money");
            builder.Property(Ex => Ex.Description).HasMaxLength(100);
            builder.Property(Ex => Ex.ExpDate).HasDefaultValueSql("getdate()");
            builder.Property(Ex => Ex.Remarks).HasMaxLength(500);
        }


    }
}
