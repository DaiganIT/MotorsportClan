using System;

public interface INotificationManager
{
    void ShowNotification(string text);
    void ShowNotificationWithLoader(string text);
    void HideNotificationWithLoader();
    void RegisterShow(EventHandler<NotificationEventArgs> delegateEvent);
    void RegisterHide(EventHandler delegateEvent);
    void UnregisterShow(EventHandler<NotificationEventArgs> delegateEvent);
    void UnregisterHide(EventHandler delegateEvent);
}