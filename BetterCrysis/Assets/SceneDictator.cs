using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDictator : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Backspace))
        {
            AsyncOperation operation = SceneManager.UnloadSceneAsync("MenuScene");
            operation.completed += asyncOperation =>
                SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
        }
    }
}
