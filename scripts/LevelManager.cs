using Godot;

public partial class LevelManager : Godot.Control
{
	//CustomMainLoopCS mainLoop =  null;
	
	
	public void StartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scene/game.tscn");
	}
	
	public void LoadButtonPressed()
	{
		//SaveManager sm = mainLoop.getSaveManager();
		//sm.LoadGame();
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
