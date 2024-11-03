using BuildingBlocks.Applictaion.Interfaces;
using Games.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Games.Persistence.Implementations;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }
}
