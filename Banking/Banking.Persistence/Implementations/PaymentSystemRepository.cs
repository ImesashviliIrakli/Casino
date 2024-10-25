using Banking.Application.Interfaces;
using Banking.Domain.Entities;
using BuildingBlocks.Domain.Enums;

namespace Banking.Persistence.Implementations;

public class PaymentSystemRepository : IPaymentSystemRepository
{
    public Task AddAsync(PaymentSystem paymentSystem, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(PaymentSystem paymentSystem, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentSystem> GetPaymentSystemByIdAsync(Guid bankId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<PaymentSystem>> GetPaymentSystemsAsync(PaymentDirection paymentDirection, bool includeTestPaymentSystems, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
