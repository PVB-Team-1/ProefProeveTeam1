using UnityEngine;

/// <summary>
/// This class represents the data for a playable level.
/// </summary>
[System.Serializable]
public class LevelData
{
	/// <summary>
	/// The name of this level.
	/// </summary>
	[Tooltip("The name of this level.")]
	public string name;

	/// <summary>
	/// The description of this level.
	/// </summary>
	[Tooltip("The description of this level.")]
	public string description;

	/// <summary>
	/// The maximum number of items that will be spawned in this level.
	/// </summary>
	[Tooltip("The maximum number of items that will be spawned in this level.")]
	public int itemSpawnNumber;

	/// <summary>
	/// All items that fit the level theme.
	/// </summary>
	[Tooltip("All items that fit the level theme.")]
	public GameObject[] items;

	/// <summary>
	/// All icons that correspond with an item.
	/// </summary>
	[Tooltip("All icons that correspond with an item.")]
	public Sprite[] itemIcons;
}