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
    }

	void Update ()
    {
		
	}

    public void OnMenuClick(int input)
    {
        MenuButton button = (MenuButton) input;

        switch(button)
        {
            case MenuButton.NEW:
                states.Push(new NewGameState());
                states.Peek().Execute();
                break;
            case MenuButton.LOAD:
                states.Push(new LoadGameState());
                states.Peek().Execute();
                break;
            case MenuButton.OPTIONS:
                states.Push(new OptionsState());
                states.Peek().Execute();
                break;
            case MenuButton.CREDITS:
                states.Push(new CreditsState());
                states.Peek().Execute();
                break;
            case MenuButton.EXIT:
                states.Push(new ExitState());
                states.Peek().Execute();
                break;

            default:
                Debug.Log("Please implement a MenuState for this");
                break;
        }
    }
}
