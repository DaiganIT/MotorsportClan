using UnityEngine;
using UnityEngine.AddressableAssets;

public class Startup : MonoBehaviour
{
    [SerializeField] AssetReference loadSceneAssetReference;

    void Awake()
    {
        // set the notification manager properties
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameManager.Instance.Initialise(
                new UnitySceneManager(),
                new UnityPlatform(new FakeBackendManager()),
                new NotificationManager(),
                new LoaderManager()
                );
        }

        if (!loadSceneAssetReference.RuntimeKeyIsValid())
        {
            Debug.LogError("Login Partial Scene Key is invalid");
            return;
        }

        GameManager.Instance.SceneManager.AddPartialView(loadSceneAssetReference);
    }
}
