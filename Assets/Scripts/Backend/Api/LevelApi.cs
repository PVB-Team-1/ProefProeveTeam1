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
	/// StartLevel calls the OnLevelStart event.
	/// </summary>
	/// <param name="level">The level index of a level that needs to be started.</param>
	public static void StartLevel(int level)
	{
		OnLevelStart?.Invoke(level);
	}

	/// <summary>
	/// EndLevel calls the OnLevelEnd event.
	/// </summary>
	/// <param name="level">The level index of a level that needs to be ended.</param>
	public static void EndLevel(int level)
	{
		OnLevelEnd?.Invoke(level);
	}

	/// <summary>
	/// PauseLevel calls the OnLevelPause event.
	/// </summary>
	/// <param name="level">The level index of a level that needs to be paused.</param>
	public static void PauseLevel(int level)
	{
		OnLevelPause?.Invoke(level);
	}

	/// <summary>
	/// ResumeLevel calls the OnLevelResume event.
	/// </summary>
	/// <param name="level">The level index of a level that needs to be resumed.</param>
	public static void ResumeLevel(int level)
	{
		OnLevelResume?.Invoke(level);
	}
}