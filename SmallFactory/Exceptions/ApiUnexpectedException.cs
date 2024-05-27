namespace SmallFactory.Exceptions
{
    public class ApiUnexpectedException() : ApiException(500, "Произошла непредвиденная ошибка... Пожалуйста, повторите попытку позже.")
    {
    }
}
