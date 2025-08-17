using Godot;
using System;

public partial class Main : Node2D
{
    PackedScene paddle;
    Area2D goalLeft;
    Area2D goalRight;

    public override void _Ready()
    {
        paddle = ResourceLoader.Load<PackedScene>("res://scenes/paddle/paddle.tscn");
        goalLeft = GetNode<Area2D>("Board/GoalLeft");
        goalRight = GetNode<Area2D>("Board/GoalRight");

        // Instantiate paddle scene
        Node2D paddleInstance = paddle.Instantiate<Node2D>();

        // Add newly instantiated scene to node tree
        AddChild(paddleInstance);

        // Set position for paddle
        paddleInstance.Position = goalLeft.Position + new Vector2(10, 0);
    }

}
