using Godot;
using System;

public partial class teste2 : CharacterBody2D
{
	public float Speed = 0;
	public const float JumpVelocity = -400.0f;
	public Vector2 inversão = new Vector2(-1,1);
	public Vector2 normal = new Vector2(1,1);


	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _Ready()
	{
			
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;		

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = new Vector2(1,0);		
		velocity.X = direction.X * Speed;	

		if(Input.IsActionJustPressed("ui_right"))
		{
			this.Scale = normal;
		}
		if(Input.IsActionJustPressed("ui_left"))
		{
			this.Scale = inversão;
		}

		

		Velocity = velocity;
		MoveAndSlide();
	}
	private void _on_area_2d_body_entered(teste2 body)
	{
		if(body.Name != "player")
		{
			GD.Print("Entrou");
		}
		body.Speed = body.Speed * -1;

	}
	private void _on_area_2d_2_body_entered(teste2 body)
	{
		if(body.Name != "player")
		{
			GD.Print("Entrou");
		}
		body.Speed = body.Speed * 1;
	}
}
