using System;

public interface IEventManager
{
    event EventHandler<string> OnEvent;
    void SendEvent(string eventName);
}
