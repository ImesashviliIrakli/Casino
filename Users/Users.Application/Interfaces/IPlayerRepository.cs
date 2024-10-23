using Users.Domain.Entities;

namespace Users.Application.Interfaces;

public interface IPlayerRepository
{
    Task<List<ApplicationUser>> GetAllPlayers();
    Task<ApplicationUser> GetPlayerById(string userId);
}
