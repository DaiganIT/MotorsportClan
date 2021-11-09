using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Startup_AccountCreation : MonoBehaviour
{
    [SerializeField] string accountCreationSceneName;
    [SerializeField] Image logoImage;

    Sprite[] availableSprites;
    int currentPosition = 0;

    private void Start()
    {
        // load logos
        GameManager.Instance.LoaderManager.ShowLoader();
        StartCoroutine(LoadLogos());
    }

    IEnumerator LoadLogos()
    {
        var imageLoader = new DiskImageLoader();
        var response = imageLoader.LoadAllImages();
        yield return new WaitUntil(() => response.isCompleted);

        availableSprites = response.data;

        // set first logo
        logoImage.sprite = availableSprites[0];
        GameManager.Instance.LoaderManager.HideLoader();
    }

    public void NextLogo()
    {
        currentPosition = (currentPosition + 1) % availableSprites.Length;
        logoImage.sprite = availableSprites[currentPosition];
    }

    public void PreviousLogo()
    {
        if (currentPosition == 0) currentPosition = availableSprites.Length - 1;
        else currentPosition = (currentPosition - 1) % availableSprites.Length;
        logoImage.sprite = availableSprites[currentPosition];
    }
}
