
using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class PostService: IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public PostService(IPostRepository postRepository, IUserRepository userRepository,IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await _postRepository.GetAllAsync();
    }
    
    public async Task<Post> GetByIdAsync(int id)
    {
        return await _postRepository.FindByIdAsync(id);
    }

    public async Task<PostResponse> SaveAsync(Post post)
    {
        //Validate if user exits
        var existingUser = await _userRepository.FindByIdAsync(post.UserId);
        if (existingUser == null) return new PostResponse("User with id " + post.UserId + " not found");

        try
        {
            await _postRepository.AddAsync(post);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(post);
        }
        catch (Exception ex)
        {
            return new PostResponse($"An error occurred while saving the post: {ex.Message}");
        }
    }

    public async Task<PostResponse> UpdateAsync(int id, Post post)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);
        if (existingPost == null) return new PostResponse("Post not found");
        existingPost.Comment = post.Comment;
        existingPost.Likes = post.Likes;
        existingPost.Photo = post.Photo;
        existingPost.Shares = post.Shares;
        existingPost.Url = post.Url;
        try
        {
            _postRepository.Update(existingPost);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(existingPost);
        }
        catch (Exception ex)
        {
            return new PostResponse($"An error occurred while updating the post: {ex.Message}");
        }
    }

    public async Task<PostResponse> DeleteAsync(int id)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);
        if (existingPost == null) return new PostResponse("Post not found");
        try
        {
            _postRepository.Remove(existingPost);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(existingPost);
        }
        catch (Exception ex)
        {
            return new PostResponse($"An error occurred while updating the post: {ex.Message}");
        }
    }
    
    public async Task<PostResponse> UpdateLikesAsync(int id, int likes)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);

        if (existingPost == null)
            return new PostResponse("Post not found.");

        existingPost.Likes = likes;

        try
        {
            _postRepository.Update(existingPost);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred while updating the likes: {e.Message}");
        }
    }

    public async Task<PostResponse> UpdateSharesAsync(int id, int shares)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);

        if (existingPost == null)
            return new PostResponse("Post not found.");

        existingPost.Shares = shares;

        try
        {
            _postRepository.Update(existingPost);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred while updating the shares: {e.Message}");
        }
    }

}