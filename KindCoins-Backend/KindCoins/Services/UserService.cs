using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Domain.Services.Communication;

namespace KindCoins_Backend.KindCoins.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ISuscriptionPlanRepository _suscriptionPlanRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository,ISuscriptionPlanRepository suscriptionPlanRepository,  IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _suscriptionPlanRepository = suscriptionPlanRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }
    
    public async Task<User> GetByIdAsync(int id)
    {
        return await _userRepository.FindByIdAsync(id);
    }
    public async Task<UserResponse> SaveAsync(User user)
    {
        //Validate if the user has a valid suscription plan
        var suscriptionPlan = await _suscriptionPlanRepository.FindByIdAsync(user.SuscriptionPlanId);
        if (suscriptionPlan == null)
            return new UserResponse("Invalid suscription plan.");
        
        //Validate if the dni is already in use
        var existingUserDni = await _userRepository.FindByDniAsync(user.DNI);
        if (existingUserDni != null)
            return new UserResponse("Dni already in use.");
        
        //Validate if the email is already in use
        var existingUser = await _userRepository.FindByEmailAsync(user.Email);
        if (existingUser != null)
            return new UserResponse("Email already in use.");
        
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(user);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the category: {e.Message}");
        }
    }
    
    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        if (existingUser == null)
            return new UserResponse("Category not found.");
        
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.DNI = user.DNI;
        existingUser.Phone = user.Phone;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.SuscriptionPlanId = user.SuscriptionPlanId;
        existingUser.Photo = user.Photo;
        
        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }
    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        if (existingUser == null)
            return new UserResponse("User not found.");
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }
}