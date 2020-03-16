using UnityEngine;
using System.Runtime.CompilerServices;

/// <summary>
/// Initializes all static constructors for this project.
/// </summary>
public class InitializeStaticConstructors : MonoBehaviour
{
	private void Awake()
	{
		RuntimeHelpers.RunClassConstructor(typeof(RandomizeFindableItems).TypeHandle);
	}
}