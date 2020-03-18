using UnityEngine;

/// <summary>
/// All global properties for this project will be defined here.
/// </summary>
public static class Properties 
{
	/// <summary>
	/// The family with corresponding persons.
	/// </summary>
	public static Family family;

	/// <summary>
	/// A container of data for all levels in the game.
	/// </summary>
	public static LevelData[] levelData;

	/// <summary>
	/// All UI screens that need to open/close at a specific time in the game.
	/// </summary>
	public static GameObject[] windows;

	/// <summary>
	/// All items that you can find in the current level.
	/// </summary>
	public static FindableItem[] currentFindableItems;
}
