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
    public DbSet<FixedExpenses> FixedExpenses => Set<FixedExpenses>();
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
        });

        modelBuilder.Entity<FixedExpenses>(entity =>
        {
            entity.Property(p => p.Description).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<Debt>(entity =>
        {
            entity.Property(p => p.ItemName).HasMaxLength(100).IsRequired();
        });
    }
}
