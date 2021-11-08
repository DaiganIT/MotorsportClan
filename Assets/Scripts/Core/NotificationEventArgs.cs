
using System;

public class NotificationEventArgs : EventArgs
{
    public NotificationEventArgs(string text)
    {
        Text = text;
    }

    public NotificationEventArgs(string text, bool hasLoader) : this(text)
    {
        HasLoader = hasLoader;
    }

    public string Text { get; private set; }
    public bool HasLoader { get; private set; }
}
