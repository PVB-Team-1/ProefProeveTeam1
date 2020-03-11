using System.Collections.Generic;

/// <summary>
/// Represents a container for the Person class.
/// </summary>
[System.Serializable]
public class Family
{
	/// <summary>
	/// Constructor of Family with a family name.
	/// </summary>
	/// <param name="name">The name of the family.</param>
	public Family(string name)
	{
		this.name = name;
	}

	/// <summary>
	/// The name of the family.
	/// </summary>
	public string name;

	/// <summary>
	/// A container for the Person class.
	/// </summary>
	public List<Person> persons = new List<Person>();
}