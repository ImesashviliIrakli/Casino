﻿namespace BuildingBlocks.Applictaion.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
