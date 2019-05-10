using System;
using UnityEngine;
using Assets;
using Assets.Menu;
using System.Collections.Generic;

public class MenuStateMachine : MonoBehaviour
{
    public enum MenuButton
    {
        NEW, LOAD, OPTIONS, CREDITS, EXIT
    }

    public Stack<MenuState> states;

	void Start ()
    {
		states = new Stack<MenuState>();
        states.Push(new MainMenuState());
        ActivateState();
    }

	void Update ()
    {
        Debug.Log("Update");
        if (Input.GetKeyDown(KeyCode.Backspace) && states.Count > 1)
        {
            states.Pop();
            ActivateState();
            Debug.Log("Test");
        }
            
	}

    public void OnMenuClick(int input)
    {
        MenuButton button = (MenuButton) input;

        switch(button)
        {
            case MenuButton.NEW:
                states.Push(new NewGameState());
                ActivateState();
                break;
            case MenuButton.LOAD:
                states.Push(new LoadGameState());
                ActivateState();
                break;
            case MenuButton.OPTIONS:
                states.Push(new OptionsState());
                ActivateState();
                break;
            case MenuButton.CREDITS:
                states.Push(new CreditsState());
                ActivateState();
                break;
            case MenuButton.EXIT:
                states.Push(new ExitState());
                ActivateState();
                break;

            default:
                Debug.Log("Please implement a MenuState for this");
                break;
        }
    }

    private void ActivateState()
    {
        states.Peek().Execute();
    }
}
