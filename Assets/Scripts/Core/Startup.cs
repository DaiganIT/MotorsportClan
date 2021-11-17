using UnityEngine;
using UnityEngine.AddressableAssets;

public class Startup : MonoBehaviour
{
    [SerializeField] AssetReference loadSceneAssetReference;
    [SerializeField] AssetReference gameSceneAssetReference;

    void Awake()
    {
        // set the notification manager properties
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameManager.Instance.Initialise(
                new UnitySceneManager(),
                new UnityPlatform(new FakeBackendManager()),
                new NotificationManager(),
                new LoaderManager(),
                new EventManager()
                );
        }

        if (!loadSceneAssetReference.RuntimeKeyIsValid())
        {
            Debug.LogError("Login Partial Scene Key is invalid");
            return;
        }
    }

    private void Start()
    {
        GameManager.Instance.LoaderManager.ShowLoader();

        GameManager.Instance.EventManager.OnEvent += EventManager_OnEvent;
        GameManager.Instance.SceneManager.AddPartialView(loadSceneAssetReference);
    }

    private void EventManager_OnEvent(object sender, string eventName)
    {
        if (eventName == EventName.LoginFinished)
        {
            var gameSceneLoadOperation = GameManager.Instance.SceneManager.SwapPartialView("Login_PartialScene", gameSceneAssetReference);
            gameSceneLoadOperation.Completed += GameSceneLoadOperation_Completed;
        }
    }

    private void GameSceneLoadOperation_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {
        GameManager.Instance.LoaderManager.HideLoader();
    }
}
