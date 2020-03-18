using UnityEngine;

/// <summary>
/// An Api class for everything about the Photo Camera.
/// </summary>
public static class PhotoCameraApi
{
	/// <summary>
	/// An event for when a photo should be created.
	/// </summary>
	public static event SimpleEvent OnCreatePhoto;

	/// <summary>
	/// An event for when a photo should be shown.
	/// </summary>
	public static event SimpleEvent OnShowPhoto;

	/// <summary>
	/// An event for when a photo finished showing.
	/// </summary>
	public static event SimpleEvent OnShowPhotoFinished;

	/// <summary>
	/// An event for when an object has been found.
	/// </summary>
	public static event IntEvent OnFoundObject;

	/// <summary>
	/// CreatePhoto calls the OnCreatePhoto event.
	/// </summary>
	public static void CreatePhoto()
	{
		OnCreatePhoto?.Invoke();
	}

	/// <summary>
	/// ShowPhoto calls the OnShowPhoto event.
	/// </summary>
	public static void ShowPhoto()
	{
		OnShowPhoto?.Invoke();
	}

	/// <summary>
	/// ShowPhotoFinished calls the OnShowPhotoFinished event.
	/// </summary>
	public static void ShowPhotoFinished()
	{
		OnShowPhotoFinished?.Invoke();
	}

	/// <summary>
	/// FoundObject calls the OnFoundObject event.
	/// </summary>
	public static void FoundObject(int foundObject)
	{
		OnFoundObject?.Invoke(foundObject);
	}
}