using BuildingBlocks.Applictaion.Interfaces;
using System.Data;

namespace Banking.Persistence.Implementations;

public class UnitOfWork : IUnitOfWork
{
    public IDbTransaction BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
