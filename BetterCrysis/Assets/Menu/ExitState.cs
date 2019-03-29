namespace Assets.Menu
{
    public class ExitState : MenuState
    {
        public override void Execute()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit;
            #endif
        }
    }
}
