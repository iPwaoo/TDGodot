using Godot;

public partial class LevelManager : Godot.Control
{
	CustomMainLoopCS mainLoop =  CustomMainLoopCS.GetInstance();
	
	private static LevelManager _instance;
	
	public static LevelManager GetInstance()
	{
		return _instance;
	}
	
	public void _Initialize()
	{
		// Initialiser le singleton
		_instance = this;
	}
	
	
	public void StartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scene/game.tscn");
	}
	
	public void LoadButtonPressed()
	{
		if (mainLoop == null){
			GD.Print("null Main Loop");
		}
		else {
			SaveManager sm = mainLoop.GetSaveManager();
			if ( sm != null){
				sm.LoadGame();
			}
			else {
				GD.Print("Save And Quit");
			}
		}
	}
	
	public void _on_options_button_pressed()
	{
		return;
	}
	
	public void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
