using UnityEngine;

/// <summary>
/// A class For zooming the camera in and out.
/// </summary>
public class CameraZooming : MonoBehaviour
{

    /// <summary>
    /// Returns the zoom level of the camera.
    /// </summary>
    public float GetZoomLevel
    {
        get
        {
            // Get the delta of the minimum- and maximum zoom distance.
            float delta = Mathf.Abs(_maxZoomDistance - _minZoomDistance);
            // Return the delta of the zoom delta and the current position of the camera.
            return Mathf.Abs(delta - transform.position.z);
        }
    }

    // Distance between 2 touches in the previous saved frame.
    private float _previousDistance = 0f;

    // Multiplier to tweak camera zoom speed.
    [SerializeField] private float _zoomSpeedModifier = 0.005f;

    [SerializeField] private float _minZoomDistance = 0.0f;
    [SerializeField] private float _maxZoomDistance = 5.0f;

    /// <summary>
    /// A simple event to call when the camera is zooming in or out.
    /// </summary>
    public SimpleEvent OnZooming;

    private void Start()
    {
        // Adding the camera's Z position to the minumum- and maximum zoom distance to make them relative to the camera's starting position.
        _minZoomDistance += transform.position.z;
        _maxZoomDistance += transform.position.z;
    }

    private void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.mouseScrollDelta.y != 0)
        {
            transform.position += new Vector3
            (
                0,
                0,
                Input.mouseScrollDelta.y
            );

            ClampPosition();
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount == 2)
        {
            // A temporary float to measure the distance between the 1st and 2nd touch on the screen.
            float currentDistance = Vector2.Distance
            (
                Input.GetTouch(0).position,
                Input.GetTouch(1).position
            );

            if (_previousDistance > 0)
            {
                // The delta between the distances of the current frame and the previous one.
                float delta = Mathf.Abs(currentDistance - _previousDistance);

                if (currentDistance > _previousDistance)
                    transform.position += new Vector3
                    (
                        0,
                        0,
                        delta * _zoomSpeedModifier
                    );
                else if (currentDistance < _previousDistance)
                    transform.position -= new Vector3
                    (
                        0,
                        0,
                        delta * _zoomSpeedModifier
                    );
            }
            _previousDistance = currentDistance;

            OnZooming?.Invoke();

            ClampPosition();

            // As long as 2 touches are registered on the screen, _previousDistance won't reset it's value back to 0.
            return;
        }
        _previousDistance = 0f;
#endif
        
    }

    /*
        Clamp the camera's position between the minimum and maximum zoom distance.
    */
    private void ClampPosition()
    {
        transform.position = new Vector3
        (
            transform.position.x,
            transform.position.y,
            Mathf.Clamp(transform.position.z, _minZoomDistance, _maxZoomDistance)
        );
    }
}
