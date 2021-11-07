using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    [SerializeField] string loadScene;

    void Awake()
    {
        var operation = SceneManager.LoadSceneAsync(loadScene, LoadSceneMode.Additive);
        operation.completed += OnSceneLoaded;
    }

    private void OnSceneLoaded(AsyncOperation op)
    {

    }
}
