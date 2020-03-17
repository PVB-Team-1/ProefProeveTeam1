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
    }

    private void SpawnFindableObjectUI(int i)
    {
        GameObject spawnedUI = Instantiate(new GameObject("UI_Image - Item_Icon"), _ItemContainer.transform.position, Quaternion.identity);
        spawnedUI.AddComponent<Image>().sprite = ;
    }
}
