using Banking.Domain.Entities;
using BuildingBlocks.Applictaion.Models.Filters;
using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Interfaces;

public interface IPaymentRequestRepository
{
    Task<List<PaymentRequest>> GetPaymentRequestsAsync(FilterParameters parameters, CancellationToken cancellationToken = default);
    Task<PaymentRequest> GetPaymentRequestByIdAsync(Guid paymentRequestId, CancellationToken cancellationToken = default);
    Task<bool> CheckForPendingRequestsAsync(string playerUserId);
    Task AddAsync(PaymentRequest paymentRequest, CancellationToken cancellationToken = default);
    void DeleteAsync(PaymentRequest paymentRequest);
}
