using BuildingBlocks.Application.Exceptions;
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
    public Player? Player { get; set; }

    public Wallet() { }

    public void Create(Currency currency, string playerUserId)
    {
        Id = Guid.NewGuid();    
        Balance = 0;
        Currency = currency;
        PlayerUserId = playerUserId;
    }

    public void AddToBalance(decimal amount)
    {
        if (amount <= 0)
            throw new ConflictException("Amount can not be less than or equal 0");

        Balance += amount;
    }

    public void RemoveFromBalance(decimal amount)
    {
        if (amount <= 0)
            throw new ConflictException("Amount can not be less than or equal 0");

        if((Balance - amount) < 0)
            throw new ConflictException("Not enough funds");

        Balance -= amount;
    }
}
