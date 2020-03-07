using System.Collections.Generic;
using UnityEngine;

public static class UIApi
{
    public delegate void GameObjectListEvent(List<GameObject> value); 

    public static event GameObjectEvent OnWindowOpen;

    public static event GameObjectEvent OnWindowClose;

    public static event GameObjectEvent OnCloseLastWindow;

    public static event GameObjectListEvent OnCloseAllWindows;


    public static List<GameObject> OpenedWindows = new List<GameObject>();

    public static void OpenWindow(int window)
    {
        OnWindowOpen?.Invoke(Properties.windows[window]);
        OpenedWindows.Add(Properties.windows[window]);
    }

    public static void CloseWindow(int window)
    {
        OnWindowClose?.Invoke(Properties.windows[window]);
    }

    public static void CloseLastWindow()
    {
        if (OpenedWindows.Count <= 0)
            return;
        
        OnCloseLastWindow?.Invoke(OpenedWindows[OpenedWindows.Count - 1]);
    }

    public static void CloseAllWindows()
    {
        if (OpenedWindows.Count <= 0)
            return;

        OnCloseAllWindows?.Invoke(OpenedWindows);
    }
}
