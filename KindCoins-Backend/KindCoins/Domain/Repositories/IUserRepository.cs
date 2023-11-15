using KindCoins_Backend.KindCoins.Domain.Models;
namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IUserRepository
{
 Task<IEnumerable<User>> ListAsync();
 Task AddAsync(User user);
 Task<User> FindByIdAsync(int id);
 void Update(User user);
 void Remove(User user);
 
 Task<User> FindByEmailAsync(string email);
 Task<User> FindByDniAsync(string dni);
}