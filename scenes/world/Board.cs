using Godot;
using System;

public partial class Board : Node2D
{
    Area2D goalLeft;
    Area2D goalRight;
    Ball ball;

    static PackedScene paddle = ResourceLoader.Load<PackedScene>("res://scenes/paddle/paddle.tscn");

    // Instantiate paddle scene
    Paddle paddleInstanceP1 = paddle.Instantiate<Paddle>();
    Paddle paddleInstanceP2cpu = paddle.Instantiate<Paddle>();

    public override void _Ready()
    {
        goalLeft = GetNode<Area2D>("GoalLeft");
        goalRight = GetNode<Area2D>("GoalRight");

        // Get the ball
        // ball = GetNode<Ball>("Ball");

        // Set position relative to paddle

        // Set playerType of paddle
        paddleInstanceP1.playerType = 0;
        paddleInstanceP2cpu.playerType = 1;

        // Set name for paddles
        paddleInstanceP1.Name = "Paddle1";
        paddleInstanceP2cpu.Name = "Paddle2";

        // Add newly instantiated paddle scenes to node tree if not already present
        if (!HasNode("Paddle1"))
        {
            AddChild(paddleInstanceP1);
        }
        if (!HasNode("Paddle2"))
        {
            AddChild(paddleInstanceP2cpu);
        }

        // Set position for paddles
        paddleInstanceP1.Position = goalLeft.Position + new Vector2(10, 0);
        paddleInstanceP2cpu.Position = goalRight.Position - new Vector2(10, 0);
    }

    public override void _Process(double delta)
    {
        // Handle input to launch ball and start round
        if (Input.IsActionPressed("launch_ball"))
        {
            // Launch the ball
            paddleInstanceP1.LaunchBall();
        }
    }

}
