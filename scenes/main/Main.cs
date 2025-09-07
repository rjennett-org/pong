using Godot;
using System;

public partial class Main : Node2D
{

    Ball ball;

    static PackedScene board = ResourceLoader.Load<PackedScene>("res://scenes/world/board.tscn");

    // Instantiate board scene
    Board boardInstance = board.Instantiate<Board>();

    State currentState;

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

        // Name boardInstance for consistent reference
        boardInstance.Name = "Board";
    }

    public override void _Process(double delta)
    {
        switch (currentState)
        {
            case State.MainMenu:
                break;
            case State.GameStart:
                if (!HasNode("Board"))
                {
                    // Load Board
                    AddChild(boardInstance);
                } 
                break;
            case State.InPlay:
                // Ball bounces around
                // Ball can score
                // When ball scores, change state to Scoring
                
                // Connect to goal signals for scoring
                ball.AreaEntered += OnBallEnteredArea;
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

    private void OnBallEnteredArea(Area2D area)
    {
        if (currentState == State.InPlay)
        {
            currentState = State.Scoring;
        }
    }
}
