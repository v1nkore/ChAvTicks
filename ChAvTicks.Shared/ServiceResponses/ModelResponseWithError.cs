namespace ChAvTicks.Shared.ServiceResponses
{
    public class ModelResponseWithError<T, TError>
    {
        public T? Model { get; init; }
        public TError? ErrorMessage { get; init; }
    }
}
