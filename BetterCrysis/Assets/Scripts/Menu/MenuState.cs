public abstract class MenuState
{
	public static MenuState State = new MainMenuState();

	public abstract void Execute();
}