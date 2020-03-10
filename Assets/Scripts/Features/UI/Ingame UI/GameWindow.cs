using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindow : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public void OpenPauseWindow()
    {
        UIApi.OpenWindow(WindowTypes.PauseMenu);
    }
}
