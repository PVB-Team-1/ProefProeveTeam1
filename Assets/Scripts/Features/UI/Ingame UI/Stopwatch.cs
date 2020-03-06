using UnityEngine;
using TMPro;

/// <summary>
/// This class controls the stopwatch in the game that keeps track of how much time it takes for the player to finish the level.
/// </summary>
public class Stopwatch : MonoBehaviour
{
    // This float keeps track of the time thats passed.
    private float _stopwatchTime = 0;

    // This bool checks whether the timer has to start or not.
    private bool _startStopwatch = false;

    // This is the text object on which the timer is displayed.
    [SerializeField] private TextMeshProUGUI _stopwatchTimer;

    private void Update()
    {
        // Enables the timer
        if (_startStopwatch)
            CountTheTime();
    }

    /// <summary>
    /// This function counts the time that has passed.
    /// </summary>
    private void CountTheTime()
    {
        _stopwatchTime += Time.deltaTime;

        DisplayTheTime();
    }

    /// <summary>
    /// This class displays the time on the text object.
    /// </summary>
    private void DisplayTheTime()
    {
        string minutes = Mathf.Floor(_stopwatchTime / 60).ToString("00");
        string seconds = Mathf.Floor(_stopwatchTime % 60).ToString("00");

        _stopwatchTimer.text = minutes + ":" + seconds;
    }

    public void EnableTheStopwatch(bool enable) { _startStopwatch = enable; }
}
