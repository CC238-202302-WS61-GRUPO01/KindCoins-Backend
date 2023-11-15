using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Domain.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> ListAsync();
    Task<PostResponse> SaveAsync(Post post);
    Task<PostResponse> UpdateAsync(int id, Post post);
    Task<PostResponse> DeleteAsync(int id);
    Task<Post> GetByIdAsync(int id);
    Task<PostResponse> UpdateLikesAsync(int id, int likes);
    Task<PostResponse> UpdateSharesAsync(int id, int shares);
}