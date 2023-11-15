namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}