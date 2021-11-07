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
    }

    private void Start()
    {
        group.alpha = 0;
    }

    public void ShowNotification(string text)
    {
        infoText.text = text;

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
        ShowNotification("This is a test notification");
    }
}
