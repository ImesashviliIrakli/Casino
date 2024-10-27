using Banking.Application.Interfaces;
using Banking.Domain.Entities;
using Banking.Persistence.Data;
using BuildingBlocks.Applictaion.Models.Filters;
using BuildingBlocks.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistence.Implementations;

public class PaymentRequestRepository : IPaymentRequestRepository
{
    private readonly AppDbContext _context;
    public PaymentRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(PaymentRequest paymentRequest, CancellationToken cancellationToken = default) =>
        await _context.PaymentRequests.AddAsync(paymentRequest, cancellationToken);

    public void DeleteAsync(PaymentRequest paymentRequest) => _context.PaymentRequests.Remove(paymentRequest);

    public async Task<PaymentRequest> GetPaymentRequestByIdAsync(Guid paymentRequestId, CancellationToken cancellationToken = default)
    {
        var paymentRequest = await _context.PaymentRequests.FirstOrDefaultAsync(x => x.Id.Equals(paymentRequestId));

        return paymentRequest;
    }

    public async Task<List<PaymentRequest>> GetPaymentRequestsAsync(FilterParameters parameters, CancellationToken cancellationToken = default)
    {
        var query = _context.PaymentRequests
            .Where(x => x.CreatedAt >= parameters.Start && x.CreatedAt <= parameters.End);

        query = parameters.OrderType == OrderType.Descending
            ? query.OrderByDescending(x => x.CreatedAt) 
            : query.OrderBy(x => x.CreatedAt);

        query = query
        .Skip(parameters.Page * parameters.PageSize)
        .Take(parameters.PageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<bool> CheckForPendingRequestsAsync(string playerUserId)
    {
        return await _context.PaymentRequests.AnyAsync(x => x.PlayerUserId.Equals(playerUserId) && x.Status.Equals(TransactionStatus.Pending));
    }
}
