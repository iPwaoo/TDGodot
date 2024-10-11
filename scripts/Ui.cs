using Godot;
using System;

public partial class Ui : CanvasLayer
{
	public Label coinscoreslbl;
	public int score = 0;
	CustomMainLoopCS mainLoop =  CustomMainLoopCS.GetInstance();

	public override void _Ready()
	{

		coinscoreslbl = GetNode<Label>("hb/coinscoreslbl");

		Godot.Collections.Array<Node> coins = GetTree().GetNodesInGroup("coins");
		for (int i = 0; i < coins.Count; i++)
		{
			Coin n = (Coin)coins[i];

			
			n.CoinCollected += AddScore;
		}
	}

	public void AddScore()
	{
		score += 1;
		coinscoreslbl.Text = "x " + score.ToString();
	}
	
	
	public Godot.Collections.Dictionary<string, Variant> Save()
	{
		return new Godot.Collections.Dictionary<string, Variant>()
		{
			{ "Filename", SceneFilePath },
			{ "Parent", GetParent().GetPath() },
			{ "score", score },
			{ "coinscoreslbl", coinscoreslbl }
		};
	}
	
	public void SaveQuitButtonPressed()
	{
		if (mainLoop == null){
			GD.Print("null Main Loop");
			GetTree().Quit();
		}
		else {
			SaveManager sm = mainLoop.GetSaveManager();
			if ( sm != null){
				sm.SaveGame();
				GetTree().Quit();
			}
			else {
				GD.Print("Save And Quit");
			}
		}
		
	}	
}
