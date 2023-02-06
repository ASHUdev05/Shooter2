using Godot;
using System;

public class Bullet : RigidBody2D
{
    public override void _Ready()
    {
        
    }

    private void _on_Timer_timeout()
    {
        QueueFree();
    }
}
