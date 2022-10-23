namespace ChAvTicks.Domain.ServiceResponses
{
    public class ErrorResponse<T>
    {
        public T? ErrorMessage { get; set; }
    }
}
