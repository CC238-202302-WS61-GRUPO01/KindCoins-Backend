namespace KindCoins_Backend.KindCoins.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    protected BaseResponse(T resource)
    {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }

    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }

}