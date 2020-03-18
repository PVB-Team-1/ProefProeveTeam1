using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Api for opening and closing UI windows.
/// </summary>
public static class UIApi
{
	/// <summary>
	/// A delegate with List of GameObject parameter.
	/// </summary>
	/// <param name="value">The corresponding windows as type GameObject.</param>
	public delegate void GameObjectListEvent(List<GameObject> value); 

	/// <summary>
	/// An event for when a window should be opened;
	/// </summary>
    public static event GameObjectEvent OnWindowOpen;

	/// <summary>
	/// An event for when the last opened window should be closed.
	/// </summary>
    public static event GameObjectEvent OnCloseLastWindow;
    
	/// <summary>
	/// An event for when all windows should be closed.
	/// </summary>
    public static event GameObjectListEvent OnCloseAllWindows;

	/// <summary>
	/// A List of all opened windows.
	/// </summary>
    public static List<GameObject> OpenedWindows = new List<GameObject>();

	/// <summary>
	/// Opens a window.
	/// </summary>
	/// <param name="window">The type of window to open.</param>
    public static void OpenWindow(WindowTypes window)
    {
        OnWindowOpen?.Invoke(Properties.windows[(int)window]);
    }

	/// <summary>
	/// Closes the last opened window.
	/// </summary>
    public static void CloseLastWindow()
    {
        if (OpenedWindows.Count <= 0)
            return;
        
        OnCloseLastWindow?.Invoke(OpenedWindows[OpenedWindows.Count - 1]);
    }

	/// <summary>
	/// Closes all opened windows.
	/// </summary>
    public static void CloseAllWindows()
    {
        if (OpenedWindows.Count <= 0)
            return;

        OnCloseAllWindows?.Invoke(OpenedWindows);
    }
}
