using Banking.Persistence.Data;
using BuildingBlocks.Applictaion.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Banking.Persistence.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }
}