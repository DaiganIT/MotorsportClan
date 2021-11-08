
using System;

public class NotificationManager : INotificationManager
{
    event EventHandler<NotificationEventArgs> OnShowNotification;
    event EventHandler OnHideNotification;

    public void ShowNotification(string text)
    {
        OnShowNotification?.Invoke(this, new NotificationEventArgs(text));
    }

    public void ShowNotificationWithLoader(string text)
    {
        OnShowNotification?.Invoke(this, new NotificationEventArgs(text, true));
    }

    public void HideNotificationWithLoader()
    {
        OnHideNotification?.Invoke(this, null);
    }

    public void RegisterShow(EventHandler<NotificationEventArgs> delegateEvent)
    {
        OnShowNotification += delegateEvent;
    }

    public void RegisterHide(EventHandler delegateEvent)
    {
        OnHideNotification += delegateEvent;
    }

    public void UnregisterShow(EventHandler<NotificationEventArgs> delegateEvent)
    {
        OnShowNotification -= delegateEvent;
    }

    public void UnregisterHide(EventHandler delegateEvent)
    {
        OnHideNotification -= delegateEvent;
    }
}
