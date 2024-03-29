using Godot;
using System;

public class player : KinematicBody2D
{
	public int Movespeed = 500;
	public int BulletSpeed = 1000;
	private PackedScene _Bullet = GD.Load<PackedScene>("res://scenes/Bullet.tscn");

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		Vector2 motion = new Vector2(0,0);

		if (Input.IsActionPressed("up"))
		{
			motion.y -= 1;
		}
		if (Input.IsActionPressed("down"))
		{
			motion.y += 1;
		}
		if (Input.IsActionPressed("left"))
		{
			motion.x -= 1;
		}
		if (Input.IsActionPressed("right"))
		{
			motion.x += 1;
		}
		motion = motion.Normalized();
		motion = MoveAndSlide(motion * Movespeed);
		LookAt(GetGlobalMousePosition());

		if (Input.IsActionPressed("LMB"))
		{
			Fire();
		}
	}

	public void Fire()
	{
		var bulletInstance = (RigidBody2D)_Bullet.Instance();
		bulletInstance.Position = GlobalPosition;
		bulletInstance.RotationDegrees = RotationDegrees;
		bulletInstance.ApplyImpulse(new Vector2(), new Vector2(BulletSpeed, 0).Rotated(Rotation));
		GetTree().Root.CallDeferred("add_child", bulletInstance);
	}

	public void Kill()
	{
		GetTree().ReloadCurrentScene();
	}

	private void _on_Area2D_body_entered(Area2D body)
	{
		if(body.Name.Contains("Enemy"))
		{
			Kill();
		}
		
	}

	private void _on_Door_body_entered(Area2D body)
	{
		StaticBody2D door = (StaticBody2D)GetParent().GetNode("StaticBody2D");
		if (body.Name.Contains("player") || body.Name.Contains("Bullet"))
		{
			if (door.RotationDegrees == 0)
			{
				door.Rotate(90);
			}
			else
			{
				door.RotationDegrees = 0;
			}
		}
	}

	private void _on_Door1_body_entered(Area2D body)
	{
		StaticBody2D door1 = (StaticBody2D)GetParent().GetNode("StaticBody2D2");
		if (body.Name.Contains("player") || body.Name.Contains("Bullet"))
		{
			if (door1.RotationDegrees == 0)
			{
				door1.Rotate(90);
			}
			else
			{
				door1.RotationDegrees = 0;
			}
		}
	}
}