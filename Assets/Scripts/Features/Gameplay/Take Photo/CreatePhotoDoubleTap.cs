using UnityEngine;

/// <summary>
/// A script to tell the game to take a picture when double tapping.
/// </summary>
public class CreatePhotoDoubleTap : MonoBehaviour
{

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.tapCount == 2)
            {
                PhotoCameraApi.CreatePhoto();

                return;
            }
        }
    }
}
