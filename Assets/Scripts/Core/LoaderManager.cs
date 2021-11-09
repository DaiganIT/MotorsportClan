using System;

public class LoaderManager : ILoaderManager
{
    event EventHandler OnShowLoader;
    event EventHandler OnHideLoader;

    public void ShowLoader()
    {
        OnShowLoader?.Invoke(this, null);
    }

    public void HideLoader()
    {
        OnHideLoader?.Invoke(this, null);
    }

    public void RegisterShow(EventHandler onShow)
    {
        OnShowLoader += onShow;
    }

    public void RegisterHide(EventHandler onHide)
    {
        OnHideLoader += onHide;
    }

    public void UnregisterShow(EventHandler onShow)
    {
        OnShowLoader -= onShow;
    }

    public void UnregisterHide(EventHandler onHide)
    {
        OnHideLoader -= onHide;
    }
}
