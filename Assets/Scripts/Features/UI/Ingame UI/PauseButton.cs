using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void PauseTheGame()
    {
        LevelApi.PauseLevel(0);
    }
}
