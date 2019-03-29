using UnityEngine;
using UnityEngine.UI;

namespace Assets.Menu
{
    public class MainMenuState : MenuState
    {
        public override void Execute()
        {
            GameObject.Find("Version").GetComponent<Text>().text = Application.version;
        }
    }
}
