using BuildingBlocks.Domain.Primitives;
using Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<GameProvider> GameProviders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<DomainEvent>();

        modelBuilder.Entity<Game>()
            .HasOne(x => x.GameProvider)
            .WithMany()
            .HasForeignKey(x => x.GameProviderId);
    }
}
