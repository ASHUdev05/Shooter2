using Godot;
using System;

public class Trail : Line2D
{
    [Export]
    int length = 50;
    Vector2 point = new Vector2();
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        GlobalPosition = new Vector2(0,0);
        GlobalRotation = 0;

        point = GetParent<Node2D>().GlobalPosition;
        AddPoint(point);
        while (GetPointCount()>length)
        {
            RemovePoint(0);
        }
    }

}