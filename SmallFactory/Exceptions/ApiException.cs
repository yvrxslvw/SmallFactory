namespace SmallFactory.Exceptions
{
    public class ApiException(int code, string message) : Exception(message)
    {
        public int Code { get; set; } = code;
    }
}
