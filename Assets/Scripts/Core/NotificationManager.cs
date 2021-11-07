
public class NotificationManager : INotificationManager
{
    NotificationWithLoader notificationWithLoader;
    Notification notification;

    public NotificationManager(Notification notification, NotificationWithLoader notificationWithLoader)
    {
        this.notification = notification;
        this.notificationWithLoader = notificationWithLoader;
    }

    public void ShowNotification(string text)
    {
        notification.ShowNotification(text);
    }

    public void ShowNotificationWithLoader(string text)
    {
        notificationWithLoader.ShowNotification(text);
    }

    public void HideNotificationWithLoader()
    {
        notificationWithLoader.HideNotification();
    }
}
