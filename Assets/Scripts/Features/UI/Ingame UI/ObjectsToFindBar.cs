using UnityEngine;
using UnityEngine.UI;

public class ObjectsToFindBar : MonoBehaviour
{
    private GameObject _ItemContainer = null;

    private void Awake()
    {
        _ItemContainer = FindObjectOfType<HorizontalLayoutGroup>().gameObject;
    }

    private void Start()
    {
        LevelApi.OnLevelStart += SpawnFindableObjectUI;
        LevelApi.StartLevel(1);
    }

    private void SpawnFindableObjectUI(int level)
    {
        int length = Properties.levelData[level - 1].itemIcons.Length;

        for (int i = 0; i < length; i++)
        {
            Image spawnedUI = Instantiate(new GameObject("UI_Image - Item_Icon"), _ItemContainer.transform.position, Quaternion.identity, _ItemContainer.transform).AddComponent<Image>();
            spawnedUI.sprite = Properties.levelData[level - 1].itemIcons[i];
            spawnedUI.preserveAspect = true;
        }
    }
}
