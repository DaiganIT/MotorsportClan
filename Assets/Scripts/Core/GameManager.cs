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

    public void Initialise(UnityPlatform platform)
    {
        if (initialized)
        {
            Debug.Log("GameManager is already initialized");
            return;
        }

        this.Platform = platform;

        initialized = true;
    }
}