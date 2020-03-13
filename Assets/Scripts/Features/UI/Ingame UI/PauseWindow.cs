using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    /// <summary>
    /// This function closes the pause window and resumes the game
    /// </summary>
    public void CloseWindow()
    {
        UIApi.CloseLastWindow();
        LevelApi.ResumeCurrentLevel();
    }
}
