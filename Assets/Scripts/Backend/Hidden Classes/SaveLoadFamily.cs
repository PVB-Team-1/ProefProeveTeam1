using UnityEngine;
using System.IO;

internal static class SaveLoadFamily
{
	private static string _saveFileName = "FamilySave.json";

    static SaveLoadFamily()
    {
		// Save Family
        SaveLoadApi.OnGameSave += () =>
		{
			string jsonString = JsonUtility.ToJson(Properties.family);
			File.WriteAllText(Application.persistentDataPath + "/" + _saveFileName, jsonString);
		};

		// Load Family
		SaveLoadApi.OnGameLoad += () =>
		{
			string jsonString = File.ReadAllText(Application.persistentDataPath + "/" + _saveFileName);
			Properties.family = JsonUtility.FromJson<Family>(jsonString);
		};
	}
}
