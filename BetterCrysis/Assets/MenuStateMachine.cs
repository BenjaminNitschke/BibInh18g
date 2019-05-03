using UnityEngine;

public class MenuStateMachine : MonoBehaviour {
	void Start () {}
	void Update () {}

	public MenuState State = new MainMenuState();

	public void OnMenuClick(int button)
	{
		switch (button)
		{
			case (int)MenuButton.New:
				State = new NewGameState();
				//TODO: SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
				//TODO: SceneManager.LoadScene("IngameUI", LoadSceneMode.Additive);
				break;
			case (int)MenuButton.Load:
				State = new LoadGameState();
				break;
			case (int)MenuButton.Options:
				State = new OptionsState();
				//TODO: new scene with Graphics, Sound and Game Options
				//TODO: add state into stack to go back From Graphics to Options to Main
				break;
			case (int)MenuButton.Credits:
				State = new CreditsState();
				break;
			case (int)MenuButton.Exit:
				State = new ExitState();
				break;
		}
		State.Execute();
	}

	public enum MenuButton
	{
		New,
		Load,
		Options,
		Credits,
		Exit
	}
}