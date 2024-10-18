using BuildingBlocks.Applictaion.Interfaces;
using System.Data;
using Users.Persistence.Data;

namespace Users.Persistence.Implementations;


public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);
}
