using Godot;
using System;

public partial class Paddle : Node2D
{
    PackedScene ball;

    public override void _Ready()
    {
        ball = ResourceLoader.Load<PackedScene>("res://scenes/ball/ball.tscn");

        // Instantiate ball scene
        Node2D ballInstance = ball.Instantiate<Node2D>();

        // Add new ball scene instance to node tree
        AddChild(ballInstance);

        // Set position for new ballInstance
        ballInstance.Position = Position + new Vector2(6,0);
    }

    // Start game with ball attached to player paddle, player1 if two players
    // Launch ball on click
    // Ball direction based on paddle collision position
}
