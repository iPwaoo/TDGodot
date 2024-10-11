using Godot;

[GlobalClass]
public partial class CustomMainLoopCS : SceneTree
{
	// Singleton instance
	private static CustomMainLoopCS _instance;
	
	private double _timeElapsed = 0;
	
	private LevelManager _levelManager;
	private SaveManager _saveManager;


	// Méthode statique pour récupérer l'instance du singleton
	public static CustomMainLoopCS GetInstance()
	{
		return _instance;
	}
	
	// Initialisation de l'instance dans _Initialize
	public override void _Initialize()
	{
		// Initialiser le singleton
		_instance = this;
		_levelManager = new LevelManager();
		_saveManager = new SaveManager();
		
		GD.Print("Initialized:");
		GD.Print($"  Starting Time: {_timeElapsed}");
	}
	
		public LevelManager GetLevelManager()
	{
		return _levelManager;
	}

		public SaveManager GetSaveManager()
	{
		return _saveManager;
	}
	
}
