using UnityEditor;
using UnityEngine;

/// <summary>
/// Adds an inspector button that will generate the window array in LoadWindows.
/// </summary>
[CustomEditor(typeof(LoadWindows))]
public class LoadWindowsEditor : Editor
{
	/// <summary>
	/// This method will add an inspector button to generate the window array in LoadWindows.
	/// </summary>
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		LoadWindows loadWindows = (LoadWindows)target;

		EditorGUILayout.Space();

		if (GUILayout.Button("Generate Window Array"))
			loadWindows.GenerateWindowArray();
	}
}