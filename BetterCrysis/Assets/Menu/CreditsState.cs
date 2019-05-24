﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Menu
{
    public class CreditsState : MenuState
    {
        public override void Execute()
        {
            Debug.Log("Developed by Jann Lüllmann");
            AsyncOperation operation = SceneManager.UnloadSceneAsync("MenuScene");
            operation.completed += asyncOperation =>
                SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
        }
    }
}
