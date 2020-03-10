using UnityEngine;

/// <summary>
/// A script to generate a photograph.
/// </summary>
public class GeneratePhoto : MonoBehaviour
{
    [SerializeField] private GameObject _picture;
    [SerializeField] private RenderTexture _renderTexture;

    /// <summary>
    /// Execute once when the component has been created.
    /// </summary>
    private void Start()
    {
        PhotoCameraApi.OnCreatePhoto += GenerateNewPhoto;
    }

    /// <summary>
    /// Create a new photograph.
    /// </summary>
    private void GenerateNewPhoto()
    {
        Renderer rend = _picture.GetComponent<Renderer>();
        rend.material.mainTexture = ToTexture2D(_renderTexture);
    }

    /// <summary>
    /// Cleanup when destroying the component.
    /// </summary>
    private void OnDestroy()
    {
        // Remove the reference so that OnCreatePhoto won't call the function on a destroyed instance of this script.
        PhotoCameraApi.OnCreatePhoto -= GenerateNewPhoto;
    }

    /// <summary>
    /// Returns a Texture2D generated from a given RenderTexture.
    /// </summary>
    /// <param name="renderTexture"></param>
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
