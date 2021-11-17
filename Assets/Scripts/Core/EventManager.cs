using System;

public class EventManager : IEventManager
{
    public event EventHandler<string> OnEvent;

    public void SendEvent(string eventName)
    {
        OnEvent?.Invoke(this, eventName);
    }
}
