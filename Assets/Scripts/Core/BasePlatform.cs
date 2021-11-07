public class BasePlatform : IPlatform
{
    public BasePlatform(INotificationManager notificationManager, IBackendManager backendManager) 
    {
        this.NotificationManager = notificationManager;
        this.BackendManager = backendManager;
    }

    public INotificationManager NotificationManager { get; protected set; }
    public IBackendManager BackendManager { get; protected set; }
}
