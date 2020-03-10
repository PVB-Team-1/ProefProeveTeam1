using UnityEngine;

public class FamilySetupTest : MonoBehaviour
{
	void Start()
	{
		UIApi.OpenWindow(WindowTypes.CharacterSetup); 
		UIApi.OpenWindow(WindowTypes.FamilySetup);
	}

	void Update()
	{
		Debug.Log("Family Created: " + Properties.family.name);
		Debug.Log("Number of persons in this family: " + Properties.family.persons.Count);
	}
}