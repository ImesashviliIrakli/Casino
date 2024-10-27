using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Models;

public class WalletDto
{
    public decimal Balance { get; set; }
    public Currency Currency { get; set; }

    public WalletDto(string balanceString, string currencyString)
    {
        if (!decimal.TryParse(balanceString, out decimal balance))
            throw new ArgumentException("Could not parse balance");

        if (!Enum.TryParse<Currency>(currencyString, true, out Currency currency))
            throw new ArgumentException($"Invalid currency: {currencyString}");

        Balance = balance;
        Currency = currency;
    }
}
