using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Notification : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
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
        GameManager.Instance.NotificationManager.RegisterShow(ShowNotification);
    }

    private void OnDestroy()
    {
        GameManager.Instance.NotificationManager.UnregisterShow(ShowNotification);
    }

    public void ShowNotification(object sender, NotificationEventArgs eventArgs)
    {
        if (eventArgs.HasLoader) return;
        infoText.text = eventArgs.Text;

        var sequence = DOTween.Sequence();

        var fadeIn = group.DOFade(1, fadeInTime).OnStart(() => { IsFadingIn = true; }).OnComplete(() => { IsFadingIn = false; IsShown = true; });
        var fadeOut = group.DOFade(0, fadeOutTime).SetDelay(duration).OnStart(() => { IsFadingOut = true; IsShown = false; }).OnComplete(() => { IsFadingOut = false; });

        sequence
            .Append(fadeIn)
            .Append(fadeOut);

        sequence.Play();
    }

    [ContextMenu("Test Notification")]
    public void TestNotification()
    {
        ShowNotification(null, new NotificationEventArgs("test"));
    }
}
