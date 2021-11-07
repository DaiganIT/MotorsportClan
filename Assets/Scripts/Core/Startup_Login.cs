using System.Collections;
using UnityEngine;

public class Startup_Login : MonoBehaviour
{
    [SerializeField] Notification notification;
    [SerializeField] NotificationWithLoader notificationWithLoader;
    [SerializeField] string loginSceneName;
    [SerializeField] string accountCreationSceneName;

    private void Start()
    {
        // dologin
        StartCoroutine(DoLogin());
    }

    IEnumerator DoLogin()
    {
        notificationWithLoader.ShowNotification("Logging in");

        var response = GameManager.Instance.Platform.BackendManager.Login(new LoginRequest { deviceId = "testDeviceId" });
        yield return new WaitUntil(() => response.isCompleted);

        notificationWithLoader.HideNotification();
        GameManager.Instance.Platform.SceneManager.SwapPartialView(loginSceneName, accountCreationSceneName);
    }
}
