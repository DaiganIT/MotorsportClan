using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class NotificationWithLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
    [SerializeField] GameObject loader;
    [SerializeField] float rotationSpeed;

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
        GameManager.Instance.NotificationManager.RegisterShow(ShowNotification);
        GameManager.Instance.NotificationManager.RegisterHide(HideNotification);
    }

    private void OnDestroy()
    {
        GameManager.Instance.NotificationManager.UnregisterShow(ShowNotification);
        GameManager.Instance.NotificationManager.UnregisterHide(HideNotification);
    }

    public void ShowNotification(object sender, NotificationEventArgs eventArgs)
    {
        if (!eventArgs.HasLoader) return;

        infoText.text = eventArgs.Text;
        var fadeIn = group.DOFade(1, fadeInTime).OnStart(() => { IsFadingIn = true; }).OnComplete(() => { IsFadingIn = false; IsShown = true; });
        fadeIn.Play();
    }

    public void HideNotification(object sender, EventArgs eventArgs)
    {
        var fadeOut = group.DOFade(0, fadeOutTime).OnStart(() => { IsFadingOut = true; IsShown = false; }).OnComplete(() => { IsFadingOut = false; });
        fadeOut.Play();
    }

    private void Update()
    {
        loader.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    [ContextMenu("Test Show Notification")]
    public void TestShowNotification()
    {
        ShowNotification(null, new NotificationEventArgs("This is a test notification", true));
    }

    [ContextMenu("Test Hide Notification")]
    public void TestHideNotification()
    {
        HideNotification(null, null);
    }
}
