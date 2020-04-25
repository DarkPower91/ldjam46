using System;


public class SaveEvents
{
    public static Action SaveInitiated = null;
    public static Action LoadInitiated = null;
    public static Action ClearSaveInitiated = null;

    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }

    public static void OnLoadInitiated()
    {
        LoadInitiated?.Invoke();
    }

    public static void OnClearSaveInitiated()
    {
        ClearSaveInitiated?.Invoke();
    }
}
