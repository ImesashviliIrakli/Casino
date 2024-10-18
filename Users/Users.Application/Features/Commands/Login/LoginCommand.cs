using BuildingBlocks.Applictaion.Features;
using Users.Application.Models;

namespace Users.Application.Features.Commands.Login;

public record LoginCommand(string email, string password) : ICommandQuery<LoginResponse>;