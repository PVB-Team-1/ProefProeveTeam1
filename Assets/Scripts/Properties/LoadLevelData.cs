using UnityEngine;

/// <summary>
/// Sends a container of the LevelData class to the Properties class.
/// </summary>
public class LoadLevelData : MonoBehaviour
{
	/// <summary>
	/// The container for all data in each level.
	/// </summary>
	[SerializeField] private LevelData[] _levelData;

	private void Awake()
	{
		Properties.levelData = _levelData;
	}
}