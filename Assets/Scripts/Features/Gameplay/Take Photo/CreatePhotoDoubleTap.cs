using System.Collections;
using UnityEngine;

/// <summary>
/// A script to tell the game to take a picture when double tapping.
/// </summary>
public class CreatePhotoDoubleTap : MonoBehaviour
{

    private bool _doubleTapEnabled = true;

    private int _clickCount = 0;

    private float _maxClickTime = 0.35f;

    private void Start()
    {
        // Disable double tapping while a photo is shown.
        PhotoCameraApi.OnShowPhotoFinished += EnableDoubleTap;
        PhotoCameraApi.OnCreatePhoto += DisableDoubleTap;
    }

    private void Update()
    {
        if (!_doubleTapEnabled)
            return;

#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        // When clicking, start a timer to check for a 2nd click.
        if (Input.GetMouseButtonDown(0))
        {
            _clickCount++;
            StartCoroutine(DoubleClickTimer());
        }

        if (_clickCount == 2)
        {
            _clickCount = 0;

            PhotoCameraApi.CreatePhoto();
        }

#endif

#if UNITY_ANDROID

        foreach (Touch touch in Input.touches)
        {
            if (touch.tapCount == 2)
            {
                PhotoCameraApi.CreatePhoto();

                return;
            }
        }

#endif

    }

    /*
        Resets click count to 0 after the maximum time to doubleclick has passed.
    */
    private IEnumerator DoubleClickTimer()
    {
        yield return new WaitForSeconds(_maxClickTime);
        _clickCount = 0;
    }

    private void EnableDoubleTap()
    {
        _doubleTapEnabled = true;
    }

    private void DisableDoubleTap()
    {
        _doubleTapEnabled = false;
    }

    private void OnDestroy()
    {
        PhotoCameraApi.OnShowPhotoFinished -= EnableDoubleTap;
        PhotoCameraApi.OnCreatePhoto -= DisableDoubleTap;
    }

}
