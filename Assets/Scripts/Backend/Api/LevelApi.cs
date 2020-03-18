/// <summary>
/// An Api class for everything about the current level.
/// </summary>
public static class LevelApi
{
	/// <summary>
	/// An event for when a level starts.
	/// </summary>
	public static event IntEvent OnLevelStart;

	/// <summary>
	/// An event for when a level ends.
	/// </summary>
	public static event IntEvent OnLevelEnd;

	/// <summary>
	/// An event for when a level pauses.
	/// </summary>
	public static event IntEvent OnLevelPause;

	/// <summary>
	/// An event for when a level resumes.
	/// </summary>
	public static event IntEvent OnLevelResume;
	
	/// <summary>
	/// The index of the current level that got started.
	/// </summary>
	public static int currentLevelIndex;

	/// <summary>
	/// StartLevel calls the OnLevelStart event.
	/// </summary>
	/// <param name="level">The level index of a level that needs to be started.</param>
	public static void StartLevel(int level)
	{
		OnLevelStart?.Invoke(level);
	}

	/// <summary>
	/// Ends the current level.
	/// </summary>
	public static void EndCurrentLevel()
	{
		OnLevelEnd?.Invoke(currentLevelIndex);
	}

	/// <summary>
	/// Pauses the current level.
	/// </summary>
	public static void PauseCurrentLevel()
	{
		OnLevelPause?.Invoke(currentLevelIndex);
	}

	/// <summary>
	/// Resumes the current level.
	/// </summary>
	public static void ResumeCurrentLevel()
	{
		OnLevelResume?.Invoke(currentLevelIndex);
	}
}