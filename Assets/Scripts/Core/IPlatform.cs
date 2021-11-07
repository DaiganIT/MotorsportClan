public interface IPlatform
{
    INotificationManager NotificationManager { get; }
    IBackendManager BackendManager { get; }
}
