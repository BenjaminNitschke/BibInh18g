using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsState : MenuState
{
	public override void Execute()
	{
		var operation = SceneManager.UnloadSceneAsync("MenuScene");
		operation.completed +=
			asyncOperation => SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
	}
}