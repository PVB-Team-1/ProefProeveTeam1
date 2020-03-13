/// <summary>
/// A window class for creating a family using a family name.
/// </summary>
public class FamilySetupWindow : InputSetupWindow
{
	/// <summary>
	/// Override of Apply method.
	/// </summary>
	public override void Apply()
	{
		if (inputText.text.Length <= 0)
			return;

		Properties.family = new Family(inputText.text);

		UIApi.CloseLastWindow();
	}
}