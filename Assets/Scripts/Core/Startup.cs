using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] Notification notification;
    [SerializeField] NotificationWithLoader notificationWithLoader;
    [SerializeField] string loadScene;

    void Awake()
    {
        // set the notification manager properties
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameManager.Instance.Initialise(
                new UnityPlatform(new UnitySceneManager(), new FakeBackendManager()),
                notification,
                notificationWithLoader
                );
        }

        GameManager.Instance.Platform.SceneManager.AddPartialView(loadScene);
    }
}
