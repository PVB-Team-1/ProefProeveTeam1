using UnityEngine;

// The vertical movement of the camera depends on the zoom level of the camera, therefore the CameraZooming script is required.
[RequireComponent(typeof(CameraZooming))]

///<summary>
/// A class that is put on the camera, to control the vertical and horizontal movement of the object.
/// Uses float boundaries to show the outer bounds of the field where the object can move.
///</summary>
public class CameraDragging : MonoBehaviour
{

    private CameraZooming _zooming;

    private float _topBoundary = 3f;
    private float _bottomBoundary = -3f;
    private float _leftBoundary = 0f;
    private float _rightBoundary = 0f;

    private float _zoomLevel;

    private bool _isDragging = false;
    private bool _canDrag = true;

    private Vector3 _oldPos;
    private Vector3 _touchOrigin;

    private Touch touch;

    [Tooltip("Determines how fast the camera moves when dragging the screen.")]
    [SerializeField]
    private float _dragSpeed = 4;

    [Tooltip("The camera boundrary on the horizontal axis.")]
    [SerializeField]
    private float _horizontalBoundary = 3f;

    [Tooltip("Modifier to tweak the vertical boundary.")]
    [SerializeField]
    private float _verticalBoundsModifier = 0.25f;

    private void Awake()
    {
        LevelApi.OnLevelResume += EnableDragging;
        LevelApi.OnLevelPause += DisableDragging;
    }

    private void Start()
    {
        // Make boundaries relative to position.
        _leftBoundary = transform.position.x - _horizontalBoundary;
        _rightBoundary = transform.position.x + _horizontalBoundary;
        _topBoundary += transform.position.y;
        _bottomBoundary += transform.position.y;

        _zooming = GetComponent<CameraZooming>();
        _zooming.OnZooming += ClampToBounds;
    }

    /*
        SavePositions saves the current position of the current object into the _oldPos private variable.
        Saves the current touch position on the moment of time, and saves it into _touchOrigin private variable.
    */
    private void SaveOriginPositions()
    {
        _oldPos = transform.position;
        _touchOrigin = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
    }

    // Moves the object according to the dragging the finger across the screen.
    private void MoveObject()
    {
        // Get the new position of the mouse relative to the _touchOrigin.
        Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position) - _touchOrigin;

        // Move the object.
        transform.position = new Vector3
        (
            _oldPos.x + -newPos.x * _dragSpeed,
            _oldPos.y + -newPos.y * _dragSpeed,
            transform.position.z
        );

        ClampToBounds();
    }

    private void Update()
    {
        if (_canDrag)
        {
            // Only run when there is not more than 1 input.
            switch (Input.touchCount)
            {
                case 1:
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (!_isDragging)
                        {
                            SaveOriginPositions();
                            _isDragging = true;
                        }
                        else
                        {
                            MoveObject();
                        }
                    }
                    break;
                case 0:
                    _isDragging = false;
                    break;
                default:
                    // Reset the _oldPos and _touchOrigin.
                    _oldPos = transform.position;
                    _touchOrigin = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                    _isDragging = false;
                    break;
            }
        }
    }

    // Clamp the object to the vertical bounds.
    private void ClampToBounds()
    {
        // Get the zoom level of the camera.
        _zoomLevel = _zooming.GetZoomLevel * _verticalBoundsModifier;

        // Clamp the object to vertical bounds.
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, _leftBoundary, _rightBoundary),
            Mathf.Clamp(transform.position.y, _zoomLevel * _bottomBoundary, _zoomLevel * _topBoundary),
            transform.position.z
        );
    }

    private void OnDestroy()
    {
        _zooming.OnZooming -= ClampToBounds;
    }

    private void EnableDragging(int i)
    {
        _canDrag = true;
    }
    
    private void DisableDragging(int i)
    {
        _canDrag = false;
    }
}
