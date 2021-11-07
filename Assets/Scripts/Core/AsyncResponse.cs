using System;

public class AsyncResponse<T>
{
    public bool isCompleted { get; set; }
    public T data { get; set; }

    internal void Complete(T response)
    {
        isCompleted = true;
        data = response;
    }
}