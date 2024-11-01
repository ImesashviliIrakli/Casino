using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Domain.Entities;

public class Wallet : Entity
{
    public decimal Balance { get; private set; }
    public Currency Currency { get; private set; }

    // Foreign Key for the Player
    [ForeignKey("UserId")]
    public string PlayerUserId { get; private set; }
    public ApplicationUser? User { get; set; }

    public Wallet() { }

    public Wallet(Currency currency, string playerUserId)
    {
        Id = Guid.NewGuid();
        Balance = 0;
        Currency = currency;
        PlayerUserId = playerUserId;
    }

    public void ChangeCurrency(Currency currency)
    {
        Currency = currency;
    }

    public void AddToBalance(decimal amount)
    {
        if (amount <= 0)
            throw new Exception("Amount can not be less than or equal 0");

        Balance += amount;
    }

    public void RemoveFromBalance(decimal amount)
    {
        if (amount <= 0)
            throw new Exception("Amount can not be less than or equal 0");

        if ((Balance - amount) < 0)
            throw new Exception("Not enough funds");

        Balance -= amount;
    }
}
