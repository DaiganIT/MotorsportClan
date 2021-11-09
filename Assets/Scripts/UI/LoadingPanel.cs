using DG.Tweening;
using System;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
    [SerializeField] float duration;
    CanvasGroup group;

    public bool IsFadingIn { get; protected set; }
    public bool IsFadingOut { get; protected set; }
    public bool IsShown { get; protected set; }

    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
    }

    private void Start()
    {
        GameManager.Instance.LoaderManager.RegisterShow(ShowLoader);
        GameManager.Instance.LoaderManager.RegisterHide(HideLoader);
    }

    private void OnDestroy()
    {
        GameManager.Instance.LoaderManager.UnregisterShow(ShowLoader);
        GameManager.Instance.LoaderManager.UnregisterHide(HideLoader);
    }

    public void ShowLoader(object sender, EventArgs eventArgs)
    {
        group.DOFade(1, fadeInTime).OnStart(() => { IsFadingIn = true; }).OnComplete(() => { IsFadingIn = false; IsShown = true; });
    }

    public void HideLoader(object sender, EventArgs eventArgs)
    {
        group.DOFade(0, fadeOutTime).SetDelay(duration).OnStart(() => { IsFadingOut = true; IsShown = false; }).OnComplete(() => { IsFadingOut = false; });
    }

    [ContextMenu("Test Loader")]
    public void TestNotification()
    {
        ShowLoader(null, null);
    }
}
