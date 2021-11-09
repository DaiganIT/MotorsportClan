using System;

public interface ILoaderManager
{
    void ShowLoader();
    void HideLoader();
    void RegisterShow(EventHandler onShow);
    void RegisterHide(EventHandler onHide);
    void UnregisterShow(EventHandler onShow);
    void UnregisterHide(EventHandler onHide);
}
