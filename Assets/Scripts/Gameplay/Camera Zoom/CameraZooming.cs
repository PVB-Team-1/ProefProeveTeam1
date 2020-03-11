using UnityEngine;

/// <summary>
/// A class For zooming the camera in and out.
/// </summary>
public class CameraZooming : MonoBehaviour
{

    // Distance between 2 touches in the previous saved frame.
    private float _previousDistance = 0f;

    // Multiplier to tweak camera zoom speed.
    [SerializeField] private float _zoomSpeedModifier = 0.5f;

    [SerializeField] private float _minZoomDistance = 0.0f;

    [SerializeField] private float _maxZoomDistance = 5.0f;

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            // A temporary float to measure the distance between the 1st and 2nd touch on the screen.
            float currentDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

            if (_previousDistance > 0)
            {
                // The delta between the distances of the current frame and the previous one.
                float delta = Mathf.Abs(currentDistance - _previousDistance);

                if (currentDistance > _previousDistance)
                {
                    transform.position += new Vector3(0, 0, delta * _zoomSpeedModifier);

                    if (transform.position.z > _maxZoomDistance)
                        transform.position -= new Vector3(0, 0, Mathf.Abs(transform.position.z - _maxZoomDistance));
                }
                else if (currentDistance < _previousDistance)
                {
                    transform.position -= new Vector3(0, 0, delta * _zoomSpeedModifier);

                    if (transform.position.z < _minZoomDistance)
                        transform.position += new Vector3(0, 0, Mathf.Abs(transform.position.z - _minZoomDistance));
                }
            }
            _previousDistance = currentDistance;

            // As long as 2 touches are registered on the screen, _previousDistance won't reset it's value back to 0.
            return;
        }
        _previousDistance = 0f;
    }
}
