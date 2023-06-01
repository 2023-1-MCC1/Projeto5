using Godot;
using System;

public partial class start : Node2D
{
	private AnimationPlayer animatedtransition;
	public override void _Ready()
	{
		animatedtransition = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_texture_button_pressed()
	{
	animatedtransition.Play("reveal");
	}

	private void _on_animation_player_animation_finished(AnimationPlayer reveal)
	{
		GetTree().ChangeSceneToFile("res://scenes/background.tscn");
	}
}
