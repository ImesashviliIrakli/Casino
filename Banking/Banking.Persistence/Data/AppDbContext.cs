using Banking.Domain.Entities;
using BuildingBlocks.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PaymentSystem> PaymentSystems { get; set; }
    public DbSet<PaymentRequest> PaymentRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<DomainEvent>();

        modelBuilder.Entity<PaymentRequest>()
            .HasOne(x => x.PaymentSystem)
            .WithMany()
            .HasForeignKey(x => x.PaymentSystemId);
    }
}
