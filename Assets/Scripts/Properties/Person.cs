using UnityEngine;

/// <summary>
/// This class represents a character.
/// </summary>
[System.Serializable]
public class Person
{
	/// <summary>
	/// Constructor of Person with a person name.
	/// </summary>
	/// <param name="name">The name of the person.</param>
	public Person(string name)
	{
		this.name = name;
	}

	/// <summary>
	/// The name of this person.
	/// </summary>
	public string name;

	/// <summary>
	/// The model of the character as type GameObject.
	/// </summary>
	public GameObject model;

	/// <summary>
	/// All transforms of the character model.
	/// </summary>
	public Transform[] transforms;
}