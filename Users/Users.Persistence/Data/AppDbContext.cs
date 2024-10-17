using BuildingBlocks.Domain.Primitives;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Users.Domain.Entities;

namespace Users.Persistence.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<DomainEvent>();

        builder.Entity<Player>().ToTable("Players");
        builder.Entity<Admin>().ToTable("Admins");

        builder.Entity<Player>()
            .HasOne(p => p.Wallet)
            .WithOne(w => w.Player)
            .HasForeignKey<Wallet>(w => w.PlayerUserId);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
