using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public interface ISceneManager
{
    public AsyncOperationHandle<SceneInstance> AddPartialView(AssetReference sceneAsset);
    public AsyncOperationHandle<SceneInstance>? RemovePartialView(string name);
    public AsyncOperationHandle<SceneInstance> SwapPartialView(string old, AssetReference replacement);
}
