public interface INotificationManager
{
    void ShowNotification(string text);
    void ShowNotificationWithLoader(string text);
    void HideNotificationWithLoader();
}
