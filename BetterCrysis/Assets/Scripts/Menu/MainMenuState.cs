using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : MenuState
{
	public override void Execute()
	{
		// Create Menu Buttons (not needed, already done in Unity Editor)
		// Update version number
		GameObject.Find("VersionText").GetComponent<Text>().text = Application.version;
	}
}