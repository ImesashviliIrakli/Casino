using Banking.Application.Interfaces;
using Banking.Domain.Entities;
using Banking.Persistence.Data;
using BuildingBlocks.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistence.Implementations;

public class PaymentSystemRepository : IPaymentSystemRepository
{
    private readonly AppDbContext _context;
    public PaymentSystemRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(PaymentSystem paymentSystem, CancellationToken cancellationToken) => 
        await _context.PaymentSystems.AddAsync(paymentSystem, cancellationToken);

    public async Task DeleteAsync(PaymentSystem paymentSystem, CancellationToken cancellationToken) =>
        await Task.Run(() => _context.PaymentSystems.Remove(paymentSystem), cancellationToken);

    public async Task<PaymentSystem> GetPaymentSystemByIdAsync(Guid paymentSystemId, CancellationToken cancellationToken)
    {
        var paymentSystem = await _context.PaymentSystems.FirstOrDefaultAsync(x => x.Id.Equals(paymentSystemId), cancellationToken);

        return paymentSystem;
    }

    public async Task<List<PaymentSystem>> GetPaymentSystemsAsync(PaymentDirection paymentDirection, bool includeTestPaymentSystems, CancellationToken cancellationToken)
    {
        var paymentSystems = await _context.PaymentSystems
        .Where(x =>
            x.PaymentDirection == paymentDirection &&
            !x.IsDisabled &&
            (includeTestPaymentSystems || !x.IsTest))
        .ToListAsync(cancellationToken);

        return paymentSystems;
    }
}
