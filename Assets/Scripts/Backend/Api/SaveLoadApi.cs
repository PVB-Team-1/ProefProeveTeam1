/// <summary>
/// An Api for saving and loading game specific properties.
/// </summary>
public static class SaveLoadApi
{
	/// <summary>
	/// An event for when the game should be saved.
	/// </summary>
	public static event SimpleEvent OnGameSave;

	/// <summary>
	/// An event for when the game should be loaded.
	/// </summary>
	public static event SimpleEvent OnGameLoad;

	/// <summary>
	/// The filename of the save file.
	/// </summary>
	public const string SaveFileName = "SaveGame.json";

	/// <summary>
	/// Saves everything about the game.
	/// </summary>
	public static void SaveGame()
	{
		OnGameSave?.Invoke();
	}

	/// <summary>
	/// Loads everything about the game.
	/// </summary>
	public static void LoadGame()
	{
		OnGameLoad?.Invoke();
	}
}