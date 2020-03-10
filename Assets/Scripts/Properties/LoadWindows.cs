using UnityEngine;
using System.Runtime.CompilerServices;

public class LoadWindows : MonoBehaviour
{
    [SerializeField] private GameObject _levelSelection         = null;
    [SerializeField] private GameObject _characterCustomization = null;
    [SerializeField] private GameObject _familySetup            = null;
    [SerializeField] private GameObject _characterSetup         = null;
    [SerializeField] private GameObject _pauseMenu              = null;
    [SerializeField] private GameObject _completionMenu         = null;
    [SerializeField] private GameObject _shopMenu               = null;

    private void Awake()
    {
        Properties.windows = new GameObject[7]
        {
            _levelSelection,
            _characterCustomization,
            _familySetup,
            _characterSetup,
            _pauseMenu,
            _completionMenu,
            _shopMenu
        };

        RuntimeHelpers.RunClassConstructor(typeof(OpenCloseWindow).TypeHandle);
    }
}
