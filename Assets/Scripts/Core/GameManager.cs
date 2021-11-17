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

    public ISceneManager SceneManager { get; private set; }
    public IPlatform Platform { get; private set; }
    public INotificationManager NotificationManager { get; private set; }
    public ILoaderManager LoaderManager { get; private set; }
    public IEventManager EventManager { get; private set; }

    static GameManager()
    {
        instance = new GameManager();
    }

    bool initialized = false;

    public void Initialise(ISceneManager sceneManager, UnityPlatform platform, INotificationManager notificationManager, ILoaderManager loaderManager, IEventManager eventManager)
    {
        if (initialized)
        {
            Debug.Log("GameManager is already initialized");
            return;
        }

        SceneManager = sceneManager;
        Platform = platform;
        NotificationManager = notificationManager;
        LoaderManager = loaderManager;
        EventManager = eventManager;

        initialized = true;
    }
}
