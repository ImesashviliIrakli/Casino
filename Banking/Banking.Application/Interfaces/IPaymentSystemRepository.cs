using Banking.Domain.Entities;
using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Interfaces;

public interface IPaymentSystemRepository
{
    Task<List<PaymentSystem>> GetPaymentSystemsAsync(PaymentDirection paymentDirection, bool includeTestPaymentSystems, CancellationToken cancellationToken);
    Task<PaymentSystem> GetPaymentSystemByIdAsync(Guid paymentSystemId, CancellationToken cancellationToken);
    Task AddAsync(PaymentSystem paymentSystem, CancellationToken cancellationToken);
    Task DeleteAsync(PaymentSystem paymentSystem, CancellationToken cancellationToken);
}
