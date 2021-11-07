using System.Collections;
using UnityEngine;

public class Startup_Login : MonoBehaviour
{
    [SerializeField] Notification notification;
    [SerializeField] NotificationWithLoader notificationWithLoader;

    private void Start()
    {
        // set the notification manager properties
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            GameManager.Instance.Initialise(new UnityPlatform(new NotificationManager(notification, notificationWithLoader), new FakeBackendManager()));
        }

        // dologin
        StartCoroutine(DoLogin());
    }

    IEnumerator DoLogin()
    {
        GameManager.Instance.Platform.NotificationManager.ShowNotificationWithLoader("Logging in");

        var response = GameManager.Instance.Platform.BackendManager.Login(new LoginRequest { deviceId = "testDeviceId" });
        yield return new WaitUntil(() => response.isCompleted);

        GameManager.Instance.Platform.NotificationManager.HideNotificationWithLoader();
    }
}
