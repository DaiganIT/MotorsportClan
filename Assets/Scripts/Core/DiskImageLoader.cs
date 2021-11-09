using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DiskImageLoader : IImageLoader
{
    public AsyncResponse<Sprite[]> LoadAllImages()
    {
        var response = new AsyncResponse<Sprite[]>();

        var operation = Addressables.LoadAssetsAsync<Sprite>("TeamLogos", (sprite) => { });
        operation.Completed += (op) => LoadLogos_Complete(op, response);

        return response;
    }

    void LoadLogos_Complete(AsyncOperationHandle<IList<Sprite>> op, AsyncResponse<Sprite[]> response)
    {
        response.Complete(op.Result.ToArray());
    }
}