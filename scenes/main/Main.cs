using Godot;
using System;

public partial class Main : Node2D
{
    Area2D goalLeft;
    Area2D goalRight;
    State currentState;

    static PackedScene paddle = ResourceLoader.Load<PackedScene>("res://scenes/paddle/paddle.tscn");

    // Instantiate paddle scene
    Paddle paddleInstanceP1 = paddle.Instantiate<Paddle>();
    Paddle paddleInstanceP2cpu = paddle.Instantiate<Paddle>();

    enum State
    {
        MainMenu,
        Paused,
        GameStart,
        InPlay,
        Scoring,
        NewRound,
        GameEnd
    }

    public override void _Ready()
    {
        // Set State to GameStart
        currentState = State.GameStart;
    }

    public override void _Process(double delta)
    {
        switch (currentState)
        {
            case State.MainMenu:
                break;
            case State.GameStart:
                goalLeft = GetNode<Area2D>("Board/GoalLeft");
                goalRight = GetNode<Area2D>("Board/GoalRight");

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

                
                // Handle input to launch ball and start round
                if (Input.IsActionPressed("launch_ball"))
                {
                    // Launch the ball
                    paddleInstanceP1.LaunchBall();

                    // Reparent ball to...baord? main?

                    // Change state to InPlay
                    currentState = State.InPlay;
                }
                break;
            case State.InPlay:
                // Ball bounces around
                // Ball can score
                break;
            case State.Scoring:
                // Handle score increment
                // Return state to GameStart for next round
                // Check for winning score and end game if reached
                break;
            case State.NewRound:
                // Spawn new ball on paddle opposite of most recent socring player
                // Handle ball launch
                break;
            case State.GameEnd:
                // Display game end menu
                // Allow return to main menu
                break;
            case State.Paused:
                // Pause the game
                // Display the pause menu
                break;
            default:
                break;
        }
    }
}
