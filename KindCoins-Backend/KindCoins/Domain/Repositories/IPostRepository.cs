using KindCoins_Backend.KindCoins.Domain.Models;

namespace KindCoins_Backend.KindCoins.Domain.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> FindByIdAsync(int id);
    Task<IEnumerable<Post>> FindByUserIdAsync(int userId);
    Task AddAsync(Post post);
    void Update(Post post);
    void Remove(Post post);
}