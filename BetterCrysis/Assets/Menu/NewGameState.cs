using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Menu
{
    public class NewGameState : MenuState
    {
        public override void Execute()
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            SceneManager.LoadScene("IngameUI", LoadSceneMode.Additive);
        }
    }
}
