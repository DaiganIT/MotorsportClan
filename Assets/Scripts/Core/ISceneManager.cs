using UnityEngine;

public interface ISceneManager
{
    public AsyncOperation AddPartialView(string name);
    public AsyncOperation RemovePartialView(string name);
    public AsyncOperation SwapPartialView(string old, string replacement);
}
