﻿namespace ChAvTicks.Domain.ServiceResponses
{
    public class ModelResponseWithError<T, TError>
    {
        public T? Model { get; set; }
        public TError? ErrorMessage { get; init; }
    }
}
