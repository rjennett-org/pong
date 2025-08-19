using Godot;
using System;

public partial class Main : Node2D
{
    Area2D goalLeft;
    Area2D goalRight;
    State currentState;

    static PackedScene paddle = ResourceLoader.Load<PackedScene>("res://scenes/paddle/paddle.tscn");

    // Instantiate paddle scene
    Paddle paddleInstance = paddle.Instantiate<Paddle>();

    enum State
    {
        GameStart,
        InPlay,
        Scoring
    }

    public override void _Ready()
    {
        goalLeft = GetNode<Area2D>("Board/GoalLeft");
        goalRight = GetNode<Area2D>("Board/GoalRight");

        // Add newly instantiated scene to node tree
        AddChild(paddleInstance);

        // Set position for paddle
        paddleInstance.Position = goalLeft.Position + new Vector2(10, 0);

        // Set State to GameStart
        currentState = State.GameStart;
    }

    public override void _Process(double delta)
    {
        if (currentState == State.GameStart)
        {
            // Handle input to launch ball and start round
            if (Input.IsActionPressed("launch_ball"))
            {
                // Launch the ball
                paddleInstance.LaunchBall();

                // Reparent ball to...baord? main?

                // Change state to InPlay
                currentState = State.InPlay;
            }
        }
        else if (currentState == State.InPlay)
        {
            // Ball bounces around
            // Ball can score
        }
        else if (currentState == State.Scoring)
        {
            // Handle score increment
            // Return state to GameStart for next round
            // Check for winning score and end game if reached
        }
    }
}
