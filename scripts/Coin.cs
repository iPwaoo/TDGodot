using Godot;
using System;

public partial class Coin : Area2D
{
	public event Action CoinCollected;

	public void OnBodyEntered(Node body)
	{
		if (body is CharacterBody2D)
		{
			CoinCollected?.Invoke();
			QueueFree();
		}
	}
	
	public Godot.Collections.Dictionary<string, Variant> Save()
	{
		return new Godot.Collections.Dictionary<string, Variant>()
		{
			{ "Filename", SceneFilePath },
			{ "Parent", GetParent().GetPath() },
			{ "PosX", Position.X }, 
			{ "PosY", Position.Y }
		};
	}	
}
