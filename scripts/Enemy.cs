using Godot;
using System;

public class Enemy : KinematicBody2D
{
	Vector2 motion = new Vector2(0,0);

	public override void _Ready()
	{
		
	}
	
	public override void _PhysicsProcess(float delta)
	{
		var Player = (KinematicBody2D)GetParent().GetNode("player");
		if ((Player.Position - Position).x < 1000)
		{
		Position += (Player.Position - Position)/50;
		//GD.Print(Player.Position - Position);
		LookAt(Player.Position);
	
		MoveAndCollide(motion);
		}
	}

	private void _on_Area2D_body_entered(Area2D body)
	{
		if(body.Name.Contains("Bullet"))
		{
			QueueFree();
		}
		
	}
}
