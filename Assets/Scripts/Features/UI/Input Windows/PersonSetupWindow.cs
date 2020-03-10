/// <summary>
/// A window class for creating a person using a persons name.
/// </summary>
public class PersonSetupWindow : InputSetupWindow
{
	/// <summary>
	/// Override of Apply method.
	/// </summary>
	public override void Apply()
	{
		if (inputText.text.Length <= 0)
			return;

		Properties.family.persons.Add(new Person(inputText.text));

		SaveLoadApi.SaveGame();

		UIApi.CloseLastWindow();
	}
}