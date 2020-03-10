using UnityEngine;
//using Unity.Mathematics;

public class CameraDragging : MonoBehaviour
{
    ///<summary>
    /// dragSpeed determines how fast the camera moves when dragging the screen
    ///</summary>
    public float dragSpeed = 1;
    public float leftBoundary = -3f;
    public float rightBoundary = 3f;
    public float upBoundary = 3f;
    public float downBoundary = -3f;
    
    private bool _cameraDragging = true;
    private Vector3 _oldPos;
    private Vector3 _mouseOrigin;
    

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            _oldPos = transform.position;
            _mouseOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0)){
            Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.mousePosition) -_mouseOrigin;

            float nextStepX = transform.position.x + -newPos.x * dragSpeed;
            float nextStepY = transform.position.y + -newPos.y * dragSpeed;

            if(nextStepX < rightBoundary && nextStepX > leftBoundary){
                transform.position = new Vector3(_oldPos.x + -newPos.x * dragSpeed, transform.position.y, transform.position.z);
                //transform.position += new Vector3(-newPos.x * dragSpeed,0,0);
            }
            if(nextStepY < upBoundary && nextStepY > downBoundary){
                transform.position = new Vector3(transform.position.x, _oldPos.y + -newPos.y * dragSpeed, transform.position.z);
                //transform.position += new Vector3(0,-newPos.y * dragSpeed,0);
            }
        }
    }
}
