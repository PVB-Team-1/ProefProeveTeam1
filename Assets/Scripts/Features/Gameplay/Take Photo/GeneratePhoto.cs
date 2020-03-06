using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script to generate a photograph.
/// </summary>
public class GeneratePhoto : MonoBehaviour
{
    [SerializeField] private GameObject _picture;
    [SerializeField] private RenderTexture _renderTexture;

    void Start() {
        //PhotoCameraApi.OnCreatePhoto += GenerateNewPhoto;
    }

    /// <summary>
    /// Create a new photograph.
    /// </summary>
    void GenerateNewPhoto() {
       Renderer rend = _picture.GetComponent<Renderer>();
        rend.material.mainTexture = ToTexture2D(_renderTexture);
    }

    /// <summary>
    /// Returns a Texture2D generated from RenderTexture "rTex".
    /// </summary>
    /// <param name="rTex"></param>
    /// <returns></returns>
    Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;
        return tex;
    }
}
