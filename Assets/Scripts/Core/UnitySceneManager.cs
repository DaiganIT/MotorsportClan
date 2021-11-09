using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class UnitySceneManager : ISceneManager
{
    IDictionary<string, SceneInstance> activeInstances;

    public UnitySceneManager()
    {
        activeInstances = new Dictionary<string, SceneInstance>();
    }

    public AsyncOperationHandle<SceneInstance> AddPartialView(AssetReference sceneAsset)
    {
        var operation = Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Additive);
        operation.Completed += LoadScene_Completed;
        return operation;
    }

    public AsyncOperationHandle<SceneInstance>? RemovePartialView(string name)
    {
        if (activeInstances.ContainsKey(name))
        {
            var operation = Addressables.UnloadSceneAsync(activeInstances[name]);
            operation.Completed += (op) => UnloadScene_Completed(name);
            return operation;
        }

        return null;
    }

    public AsyncOperationHandle<SceneInstance> SwapPartialView(string old, AssetReference replacement)
    {
        RemovePartialView(old);
        return AddPartialView(replacement);
    }

    private void LoadScene_Completed(AsyncOperationHandle<SceneInstance> sceneOperation)
    {
        activeInstances.Add(sceneOperation.Result.Scene.name, sceneOperation.Result);
    }

    private void UnloadScene_Completed(string name)
    {
        activeInstances.Remove(name);
    }
}