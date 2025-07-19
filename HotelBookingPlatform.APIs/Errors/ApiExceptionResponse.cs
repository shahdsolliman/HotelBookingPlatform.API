namespace SnapShop.API.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public ApiExceptionResponse(int statusCode, string? message = null, string? deatails = null) : base(statusCode, message)
        {
            Deatails = deatails;
        }
        public string? Deatails { get; set; }
    }
}
