using Godot;
using System;

public partial class Ui : CanvasLayer
{
	public Label coinscoreslbl;
	public int score = 0;
	//CustomMainLoopCS mainLoop =  null;

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
		//SaveManager sm = mainLoop.getSaveManager();
		//sm.SaveGame();
		GetTree().Quit();
	}	
}
