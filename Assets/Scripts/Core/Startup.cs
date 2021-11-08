using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] string loadScene;

    void Awake()
    {
        // set the notification manager properties
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameManager.Instance.Initialise(
                new UnityPlatform(new UnitySceneManager(), new FakeBackendManager()),
                new NotificationManager()
                );
        }

        GameManager.Instance.Platform.SceneManager.AddPartialView(loadScene);
    }
}
