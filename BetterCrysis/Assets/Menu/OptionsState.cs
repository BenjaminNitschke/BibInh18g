using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Menu
{
    public class OptionsState : MenuState
    {
        public override void Execute()
        {
            SceneManager.LoadScene("OptionsScene", LoadSceneMode.Single);
        }
    }
}
