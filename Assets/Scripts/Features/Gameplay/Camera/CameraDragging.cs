using UnityEngine;

///<summary>
/// A class that is put on the camera, to control the vertical and horizontal movement of the object.
/// Uses public float boundaries to show the outer bounds of the field where the object can move.
///</summary>
public class CameraDragging : MonoBehaviour
{
    [SerializeField]
    ///<summary>
    /// dragSpeed determines how fast the camera moves when dragging the screen.
    ///</summary>
    public float dragSpeed = 4;
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

    private Vector3 _oldPos;
    private Vector3 _mouseOrigin;

    private bool FoundMultipleTouches()
    {
        return Input.touchCount > 1;
    }

    /*
        SavePositions saves the current position of the current object into the _oldPos private variable.
        Saves the current mouse position on the moment of time, and saves it into _mouseOrigin private variable.
    */
    private void SaveOriginPositions()
    {
        _oldPos = transform.position;
        _mouseOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    /*
        Moves the object according to the dragging the cursor/finger across the screen.
    */
    private void MoveObject()
    {
        //Get the new position of the mouse relative to the _mouseOrigin
        Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - _mouseOrigin;

        //Calculate the position of the next step, for checking if the next position is over a boundary
        float nextStepX = transform.position.x + -newPos.x * dragSpeed;
        float nextStepY = transform.position.y + -newPos.y * dragSpeed;

        //Check if the nextSteps are outside the boundaries
        if (nextStepX < rightBoundary && nextStepX > leftBoundary)
        {
            //move the object horizontally
            transform.position = new Vector3(_oldPos.x + -newPos.x * dragSpeed, transform.position.y, transform.position.z);
        }
        if (nextStepY < upBoundary && nextStepY > downBoundary)
        {
            //move the object vertically
            transform.position = new Vector3(transform.position.x, _oldPos.y + -newPos.y * dragSpeed, transform.position.z);
        }
    }
    private void Update()
    {
        //only run when there is not more than 1 input.
        if (!FoundMultipleTouches())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SaveOriginPositions();
            }

            if (Input.GetMouseButton(0))
            {
                MoveObject();
            }
        } 
        
        if(FoundMultipleTouches()){
            //reset the _oldPos and _mouseOrigin
            _oldPos = transform.position;
            _mouseOrigin = Input.mousePosition;
        }
    }
}
