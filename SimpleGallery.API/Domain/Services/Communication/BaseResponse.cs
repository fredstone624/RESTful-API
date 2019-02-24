namespace SimpleGallery.API.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}