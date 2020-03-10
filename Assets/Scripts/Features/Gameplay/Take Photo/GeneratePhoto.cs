using UnityEngine;

/// <summary>
/// A script to generate a photograph.
/// </summary>
public class GeneratePhoto : MonoBehaviour
{

    [SerializeField] private GameObject _picture;

    [SerializeField] private RenderTexture _renderTexture;

    private void Start()
    {
        PhotoCameraApi.OnCreatePhoto += GenerateNewPhoto;
    }

    private void GenerateNewPhoto()
    {
        Renderer rend = _picture.GetComponent<Renderer>();
        rend.material.mainTexture = ToTexture2D(_renderTexture);
    }

    private void OnDestroy()
    {
        // Remove the reference so that OnCreatePhoto won't call the function on a destroyed instance of this script.
        PhotoCameraApi.OnCreatePhoto -= GenerateNewPhoto;
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
