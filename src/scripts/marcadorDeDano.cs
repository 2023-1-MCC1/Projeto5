using Godot;
using System;

public partial class marcadorDeDano : Label
{
	
	public player gato;
	public override void _Ready()
	{
		gato = this.GetParent().GetNode<player>("player");
		this.Text = "-" + gato.atk;		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
