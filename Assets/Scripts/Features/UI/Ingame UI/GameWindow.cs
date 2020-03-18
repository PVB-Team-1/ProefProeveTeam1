using UnityEngine;

public class GameWindow : MonoBehaviour
{
    /// <summary>
    /// This function opens the pause window and pauses the game
    /// </summary>
    public void OpenPauseWindow()
    {
        UIApi.OpenWindow(WindowTypes.PauseMenu);
        LevelApi.PauseCurrentLevel();
    }
}
