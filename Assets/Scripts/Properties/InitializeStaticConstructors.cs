using UnityEngine;
using System.Runtime.CompilerServices;

/// <summary>
/// Initializes all static constructors for this project.
/// </summary>
public class InitializeStaticConstructors : MonoBehaviour
{
	private void Start()
	{
		RuntimeHelpers.RunClassConstructor(typeof(SaveLoadFamily).TypeHandle);
	}
}