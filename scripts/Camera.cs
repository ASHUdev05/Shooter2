using Godot;
using System;

public class Camera : Camera2D
{
    private KinematicBody2D Player;
    
    public override void _Ready()
    {
        Player = GetNode<KinematicBody2D>("/root/world/player");
    }

    public override void _Process(float delta)
    {
        Position = new Vector2(Player.Position.x, Player.Position.y);
    }
}
