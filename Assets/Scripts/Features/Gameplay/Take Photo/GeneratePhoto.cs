using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script to generate and show a photograph.
/// </summary>
public class GeneratePhoto : MonoBehaviour
{

    [Tooltip("How long the photo stays on screen before it disappears again.")]
    [Range(0.5f, 3f)]
    [SerializeField]
    private float _photoScreenTime = 1.5f;

    [Tooltip("The RenderTexture that will hold the camera's rendering data.")]
    [SerializeField]
    private RenderTexture _renderTexture;

    private Image _backdrop = null;
    private RawImage _foregroundImage = null;

    private void Start()
    {
        // Subscribe to PhotoCameraApi's events.
        PhotoCameraApi.OnCreatePhoto += CreatePhoto;
        PhotoCameraApi.OnShowPhoto += ShowPhoto;

        // Get the foreground and backdrop images.
        _foregroundImage = GetComponentInChildren<RawImage>();
        _backdrop = GetComponent<Image>();
    }

    private void CreatePhoto()
    {
        _foregroundImage.texture = ToTexture2D(_renderTexture);

        PhotoCameraApi.ShowPhoto();
    }

    private void ShowPhoto()
    {
        _foregroundImage.enabled = true;
        _backdrop.enabled = true;

        StartCoroutine(HidePhotoRoutine());
    }

    private IEnumerator HidePhotoRoutine()
    {
        yield return new WaitForSeconds(_photoScreenTime);

        // Disable the foreground and backdrop images to reduce draw calls.
        _foregroundImage.enabled = false;
        _backdrop.enabled = false;

        PhotoCameraApi.ShowPhotoFinished();
    }

    private void OnDestroy()
    {
        // Remove the subscriptions to PhotoCameraApi's events.
        PhotoCameraApi.OnCreatePhoto -= CreatePhoto;
        PhotoCameraApi.OnShowPhoto += ShowPhoto;
    }

    private Texture2D ToTexture2D(RenderTexture renderTexture)
    {
        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;

        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        RenderTexture.active = null;

        return tex;
    }
}
