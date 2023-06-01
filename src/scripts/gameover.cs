using Godot;
using System;

public partial class gameover : CanvasLayer
{
	private AnimationPlayer animatedtransition;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedtransition = GetNode<AnimationPlayer>("transition");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_texture_button_pressed()
	{
		animatedtransition.Play("reveal2");
	}

	private void _on_transition_animation_finished(AnimationPlayer reveal2)
	{
		GetTree().ChangeSceneToFile("res://scenes/background.tscn");
	}

	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/creditos.tscn");
	}
}
