﻿using DG.Tweening;
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
    }

    private void Start()
    {
        group.alpha = 0;
    }

    public void ShowNotification(string text)
    {
        infoText.text = text;
        var fadeIn = group.DOFade(1, fadeInTime).OnStart(() => { IsFadingIn = true; }).OnComplete(() => { IsFadingIn = false; IsShown = true; });
        fadeIn.Play();
    }

    public void HideNotification()
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
        ShowNotification("This is a test notification");
    }

    [ContextMenu("Test Hide Notification")]
    public void TestHideNotification()
    {
        HideNotification();
    }
}