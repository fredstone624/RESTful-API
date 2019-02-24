namespace SimpleGallery.API.Domain.Services.Communication
{
    /// <summary>Creates a response when saving</summary>
    /// <typeparam name="T">Сlass to save</typeparam>
    public class SaveResponse<T> : BaseResponse
        where T : class
    {
        public T Value { get; private set; }

        private SaveResponse(bool success, string message, T value) 
            : base(success, message)
        {
            Value = value;
        }

        /// <summary>Creates a success response</summary>
        /// <param name="category">Saved values</param>
        /// <returns>Response</returns>
        public SaveResponse(T value) 
            : this(true, string.Empty, value)
        {
        }

        /// <summary>Creates am error response</summary>
        /// <param name="message">Error message</param>
        /// <returns>Response</returns>
        public SaveResponse(string message) 
            : this(false, message, null)
        {
        }
    }
}