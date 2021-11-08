using UnityEngine;

public class GameManager
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }

    public IPlatform Platform { get; private set; }

    static GameManager()
    {
        instance = new GameManager();
    }

    bool initialized = false;

    public Notification Notification { get; private set; }
    public NotificationWithLoader NotificationWithLoader { get; private set; }

    public void Initialise(UnityPlatform platform, Notification notification, NotificationWithLoader notificationWithLoader)
    {
        if (initialized)
        {
            Debug.Log("GameManager is already initialized");
            return;
        }

        Platform = platform;
        Notification = notification;
        NotificationWithLoader = notificationWithLoader;

        initialized = true;
    }
}