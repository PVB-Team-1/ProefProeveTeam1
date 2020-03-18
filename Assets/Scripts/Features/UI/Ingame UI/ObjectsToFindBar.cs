using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A UI bar for objects that you need to find and have been found.
/// </summary>
public class ObjectsToFindBar : MonoBehaviour
{
    private GameObject _itemContainer = null;

    private List<Image> _foundObjects = new List<Image>();
	private Image _foundObjectTemp = null;
    private Image[] _spawnedImages = null;

	[Tooltip("How fast the icons of the items fade in/out.")]
	[SerializeField] private float _fadeSpeed = 0.2f;

	private void Awake()
    {
        _itemContainer = FindObjectOfType<HorizontalLayoutGroup>().gameObject;

        PhotoCameraApi.OnFoundObject += ObjectFound;
		PhotoCameraApi.OnShowPhotoFinished += ShowPhotoFinished;
    }

    private void Start()
    {
        LevelApi.OnLevelStart += SpawnFindableObjectUI;
    }

    private void Update()
    {
		if (_foundObjects.Count > 0)
		{
			for (int i = 0; i < _foundObjects.Count; i++)
				LerpImageColor(_foundObjects[i], Color.black, Color.white, _fadeSpeed);
		}
    }

    private void LerpImageColor(Image image, Color from, Color to, float _fadeSpeed)
    {
		if (image.color.r < 1 && image.color.g < 1 && image.color.b < 1)
			image.color += Color.Lerp(from, to, _fadeSpeed * Time.deltaTime);
		else
			_foundObjects.RemoveAt(0);
    }

    private void ObjectFound(int foundObject)
    {
		_foundObjectTemp = _spawnedImages[foundObject];
    }

	private void ShowPhotoFinished()
	{
		_foundObjects.Add(_foundObjectTemp);
	}

    private void SpawnFindableObjectUI(int level)
    {
		int length = Properties.currentFindableItems.Length;
		_spawnedImages = new Image[length];

        for (int i = 0; i < length; i++)
        {
			// Null icon check
			if (!Properties.currentFindableItems[i].icon)
			{
				Debug.LogWarning("The icon from item " + i + " is null.");
				continue;
			}

            Image spawnedUI = Instantiate(new GameObject("UI_Image - Item_Icon"), _itemContainer.transform.position, Quaternion.identity, _itemContainer.transform).AddComponent<Image>();
            spawnedUI.sprite = Properties.currentFindableItems[i].icon;
            spawnedUI.color = Color.black;
            spawnedUI.preserveAspect = true;
			spawnedUI.useSpriteMesh = true;

            _spawnedImages[i] = spawnedUI;
        }
    }
}
