using UnityEditor.Animations;
using UnityEngine;

public partial class MenuStateMachine : MonoBehaviour {
	void Start () {}
	void Update () {}

	public void OnMenuClick(int button)
	{
		switch (button)
		{
			case (int)MenuButton.Game:
				MenuState.State = new NewGameState();
				break;
			case (int)MenuButton.Load:
				MenuState.State = new LoadGameState();
				break;
			case (int)MenuButton.Options:
				MenuState.State = new OptionsState();
				//TODO: new scene with Graphics, Sound and Game Options
				//TODO: add state into stack to go back From Graphics to Options to Main
				break;
			case (int)MenuButton.Credits:
				MenuState.State = new CreditsState();
				break;
			case (int)MenuButton.Exit:
				MenuState.State = new ExitState();
				break;
		}
		MenuState.State.Execute();
	}
}