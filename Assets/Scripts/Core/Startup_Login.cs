using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Startup_Login : MonoBehaviour
{
    [SerializeField] string loginSceneName;
    [SerializeField] AssetReference accountCreationSceneName;

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
        GameManager.Instance.SceneManager.SwapPartialView(loginSceneName, accountCreationSceneName);
    }
}
