using UnityEngine;

///<summary>
/// A class that is put on the camera, to control the vertical and horizontal movement of the object.
/// Uses public float boundaries to show the outer bounds of the field where the object can move.
///</summary>
public class CameraDragging : MonoBehaviour
{
    [SerializeField]
    ///<summary>
    /// The camera boundary on the left side.
    ///</summary>
    public float leftBoundary = -3f;
    ///<summary>
    /// The camera boundary on the right side.
    ///</summary>
    public float rightBoundary = 3f;
    ///<summary>
    /// The camera boundary on the upper side.
    ///</summary>
    public float upBoundary = 3f;
    ///<summary>
    /// The camera boundary on the lower side.
    ///</summary>
    public float downBoundary = -3f;

    ///<summary>
    /// dragSpeed determines how fast the camera moves when dragging the screen.
    ///</summary>
    [SerializeField]
    private float _dragSpeed = 4;

    private bool _isDragging = false;

    private Vector3 _oldPos;
    private Vector3 _touchOrigin;

    private Touch touch;

    /*
        SavePositions saves the current position of the current object into the _oldPos private variable.
        Saves the current touch position on the moment of time, and saves it into _touchOrigin private variable.
    */
    private void SaveOriginPositions()
    {
        _oldPos = transform.position;
        _touchOrigin = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
    }

    /*
        Moves the object according to the dragging the finger across the screen.
    */
    private void MoveObject()
    {
        //Get the new position of the mouse relative to the _touchOrigin
        Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position) - _touchOrigin;

        //Calculate the position of the next step, for checking if the next position is over a boundary
        float nextStepX = transform.position.x + -newPos.x * _dragSpeed;
        float nextStepY = transform.position.y + -newPos.y * _dragSpeed;

        //Check if the nextSteps are outside the boundaries
        if
        (
            nextStepX < rightBoundary &&
            nextStepX > leftBoundary
        )
        {
            //move the object horizontally
            transform.position = new Vector3
            (
                _oldPos.x + -newPos.x * _dragSpeed,
                transform.position.y,
                transform.position.z
            );
        }
        if
        (
            nextStepY < upBoundary &&
            nextStepY > downBoundary
        )
        {
            //move the object vertically
            transform.position = new Vector3
            (
                transform.position.x,
                _oldPos.y + -newPos.y * _dragSpeed,
                transform.position.z
            );
        }
    }
    private void Update()
    {
        //only run when there is not more than 1 input.
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
                //reset the _oldPos and _touchOrigin
                _oldPos = transform.position;
                _touchOrigin = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
                _isDragging = false;
                break;
        }
    }
}
