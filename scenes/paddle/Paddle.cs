using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    static PackedScene ball = ResourceLoader.Load<PackedScene>("res://scenes/ball/ball.tscn");
    // Instantiate ball scene
    Ball ballInstance = ball.Instantiate<Ball>();

    Node2D board;

    private int _speed = 150;

    public override void _Ready()
    {
        board = GetNode<Node2D>("../Board");

        // Add new ball scene instance to node tree
        AddChild(ballInstance);

        // Start game with ball attached to player paddle, player1 if two players
        // Set position for new ballInstance
        ballInstance.Position = Position + new Vector2(6, 0);
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndCollide(Velocity * (float)delta);
    }


    public void GetInput()
    {
        float inputY = Input.GetAxis("up_w", "down_s");

        // Provide 0 X and calculated Y for only vertical movement
        Velocity = new Vector2(0f, inputY * _speed);
    }

    // Launch ball on input
    public void LaunchBall()
    {
        ballInstance.Launch();
        ballInstance.Reparent(board);
    }
    
    // Ball direction based on paddle collision position
}
