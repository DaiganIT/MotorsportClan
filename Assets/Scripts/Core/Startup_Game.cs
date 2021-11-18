using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class Startup_Game : MonoBehaviour
{
    [SerializeField] AssetReference defaultCar;
    [SerializeField] CinemachineVirtualCamera chaseCamera;
    [SerializeField] float environmentPieceLength = 5f;
    [SerializeField] string environmentDefaultLabel = "default";
    [SerializeField] string environmentPrefix = "environments/{0}";

    IList<GameObject> environmentsPieces;

    private void Start()
    {
        var scene = gameObject.scene;
        SceneManager.SetActiveScene(scene);

        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        // load car
        var car = PlayerPrefs.GetString("Car");
        if (string.IsNullOrEmpty(car))
        {
            // load default car
            car = defaultCar.AssetGUID;
        }
        var loadCarOperation = Addressables.LoadAssetAsync<GameObject>(car);
        yield return loadCarOperation;

        if (loadCarOperation.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("Loading Car Failed");
            yield break;
        }

        var playerCar = Instantiate(loadCarOperation.Result);
        chaseCamera.m_Follow = playerCar.transform;

        // load initial environment
        var env = PlayerPrefs.GetString("Env");
        if (string.IsNullOrEmpty(env))
        {
            // load default environment
            env = environmentDefaultLabel;
        }
        var loadEnvOperation = Addressables.LoadAssetsAsync<GameObject>($"{environmentPrefix}{env}", null);
        yield return loadEnvOperation;

        if (loadEnvOperation.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("Loading Environment Failed");
            yield break;
        }

        environmentsPieces = loadEnvOperation.Result;

        // spawn 3 random environments.
        for(int i = 0; i < 3; i++)
        {
            var randomPiece = environmentsPieces[Random.Range(0, environmentsPieces.Count)];
            var createdPiece = Instantiate(randomPiece);
            createdPiece.transform.position = new Vector3(0, 0, i * environmentPieceLength);
        }

        // load ui

        // send event all finished
        GameManager.Instance.EventManager.SendEvent(EventName.LoadingGameFinished);
        GameManager.Instance.LoaderManager.HideLoader();
    }
}
