using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Setup windows can inherit from this class.
/// Inheriting from this class requires your window to have a Text component for input that you can apply.
/// This class could be used for applying a username.
/// </summary>
public abstract class InputSetupWindow : MonoBehaviour
{
	[SerializeField] protected Text inputText;

	/// <summary>
	/// This will be executed when you apply the specified input.
	/// </summary>
	public abstract void Apply();
}