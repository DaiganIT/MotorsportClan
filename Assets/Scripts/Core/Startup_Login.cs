using System.Collections;
using UnityEngine;

public class Startup_Login : MonoBehaviour
{
    private void Start()
    {
        // dologin
        StartCoroutine(DoLogin());
    }

    IEnumerator DoLogin()
    {
        GameManager.Instance.NotificationManager.ShowNotificationWithLoader("Logging in");

        var response = GameManager.Instance.Platform.BackendManager.Login(new LoginRequest { deviceId = "testDeviceId" });
        yield return new WaitUntil(() => response.isCompleted);

        GameManager.Instance.NotificationManager.HideNotificationWithLoader();
        GameManager.Instance.EventManager.SendEvent(EventName.LoginFinished);
    }
}
