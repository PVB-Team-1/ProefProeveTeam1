using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    public void CloseWindow()
    {
        UIApi.CloseLastWindow();
    }
}
