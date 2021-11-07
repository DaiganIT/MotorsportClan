using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitySceneManager : ISceneManager
{
    public AsyncOperation AddPartialView(string name)
    {
        return SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public AsyncOperation RemovePartialView(string name)
    {
        return SceneManager.UnloadSceneAsync(name);
    }

    public AsyncOperation SwapPartialView(string old, string replacement)
    {
        RemovePartialView(old);
        return AddPartialView(replacement);
    }
}