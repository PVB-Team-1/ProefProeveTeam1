using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private float _stopwatchTime = 0;

    private bool _startStopwatch = false;

    [SerializeField] private TextMeshProUGUI _stopwatchTimer;

    private void Update()
    {
        if (_startStopwatch)
            CountTheTime();
    }

    private void CountTheTime()
    {
        _stopwatchTime += Time.deltaTime;

        DisplayTheTime();
    }

    private void DisplayTheTime()
    {
        string minutes = Mathf.Floor(_stopwatchTime / 60).ToString("00");
        string seconds = Mathf.Floor(_stopwatchTime % 60).ToString("00");

        _stopwatchTimer.text = minutes + ":" + seconds;
    }

    public void EnableTheStopwatch(bool enable) { _startStopwatch = enable; }
}
