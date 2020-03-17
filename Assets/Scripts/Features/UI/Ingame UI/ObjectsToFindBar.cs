﻿using UnityEngine;
using UnityEngine.UI;

public class ObjectsToFindBar : MonoBehaviour
{
    private GameObject _itemContainer = null;

    private Image _foundObject = null;
    private Image[] _spawnedImages = null;

    private bool _lerpColor = false;

    private void Awake()
    {
        _itemContainer = FindObjectOfType<HorizontalLayoutGroup>().gameObject;

        PhotoCameraApi.OnFoundObject += ObjectFound;
    }

    private void Start()
    {
        LevelApi.OnLevelStart += SpawnFindableObjectUI;
        LevelApi.StartLevel(1);
    }

    private void Update()
    {
        if(_lerpColor)
            LerpImageColor(_foundObject, Color.black, Color.white, 3);
    }

    private void LerpImageColor(Image image, Color from, Color to, float duration)
    {
        if (image.color != Color.white)
            image.color = Color.Lerp(from, to, duration * Time.deltaTime);
        else
            _lerpColor = false;
    }

    private void ObjectFound(int foundObject)
    {
        _foundObject = _spawnedImages[foundObject];
        _lerpColor = true;
    }

    private void SpawnFindableObjectUI(int level)
    {
        int length = Properties.levelData[level - 1].itemIcons.Length;
        _spawnedImages = new Image[length];

        for (int i = 0; i < length; i++)
        {
            Image spawnedUI = Instantiate(new GameObject("UI_Image - Item_Icon"), _itemContainer.transform.position, Quaternion.identity, _itemContainer.transform).AddComponent<Image>();
            spawnedUI.sprite = Properties.levelData[level - 1].itemIcons[i];
            spawnedUI.color = Color.black;
            spawnedUI.preserveAspect = true;

            _spawnedImages[i] = spawnedUI;
        }
    }
}
