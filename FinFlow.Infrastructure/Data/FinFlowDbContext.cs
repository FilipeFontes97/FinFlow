using FinFlow.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Infrastructure.Data;

public class FinFlowDbContext : DbContext
{
    public FinFlowDbContext(DbContextOptions<FinFlowDbContext> options)
        : base(options)
    {
    }

    //DbSets — each entity of domain represents a table.
    public DbSet<FinancialAccount> FinancialAccounts => Set<FinancialAccount>();
    public DbSet<FixedExpense> FixedExpenses => Set<FixedExpense>();
    public DbSet<Debt> Debts => Set<Debt>();
    public DbSet<DebtPayment> DebtPayments => Set<DebtPayment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FinancialAccount>(entity =>
        {
            entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
            entity.Property(p => p.Notes).HasMaxLength(500);
            entity.Property(p => p.Type).HasConversion<string>().HasMaxLength(50).IsRequired();
            entity.Property(e => e.ValueInvested).HasPrecision(18, 2);
            entity.Property(e => e.CurrentValue).HasPrecision(18, 2);
            entity.Property(p => p.DateCreated).HasColumnName("DateCreated");
        });

        modelBuilder.Entity<FixedExpense>(entity =>
        {
            entity.Property(e => e.MonthlyAmount).HasPrecision(18, 2);
            entity.Property(p => p.Category).HasConversion<string>().HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Debt>(entity =>
        {
            entity.Property(p => p.ItemName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
            entity.Property(e => e.AmountPaid).HasPrecision(18, 2);
        });

        modelBuilder.Entity<DebtPayment>(entity =>
        {
            entity.Property(e => e.Amount).HasPrecision(18, 2);

            entity.Property(p => p.Date)
                          .HasColumnName("Date");

        });
    }
}
