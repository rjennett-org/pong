using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    static PackedScene ball = ResourceLoader.Load<PackedScene>("res://scenes/ball/ball.tscn");
    // Instantiate ball scene
    Ball ballInstance = ball.Instantiate<Ball>();

    Node2D board;

    private int _speed = 150;
    public int playerType;

    public override void _Ready()
    {
        // Get parent Board and cast to Node2D
        board = (Node2D)GetParent();

        switch (playerType)
        {
            // Player1
            case 0:

                // Add new ball scene instance to node tree
                AddChild(ballInstance);

                // Start game with ball attached to player paddle, player1 if two players
                // Set position for new ballInstance
                ballInstance.Position = Position + new Vector2(6, 0);

                break;

            // Player2
            case 1:
                break;
            // PlayerCPU
            case 2:
                break;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndCollide(Velocity * (float)delta);
    }


    public void GetInput()
    {
        // Use PlayerType to determine control scheme
        switch (playerType)
        {
            case 0:
                float inputYP1 = Input.GetAxis("up_w", "down_s");
                // Provide 0 X and calculated Y for only vertical movement
                Velocity = new Vector2(0f, inputYP1 * _speed);
                break;
            case 1:
                float inputYP2 = Input.GetAxis("up_up", "down_down");
                // Provide 0 X and calculated Y for only vertical movement
                Velocity = new Vector2(0f, inputYP2 * _speed);
                break;
            case 2:
                // No input for CPU control
                break;
        }


    }

    // Launch ball on input
    public void LaunchBall()
    {
        ballInstance.Launch();
        ballInstance.Reparent(board);
    }
    
    // Ball direction based on paddle collision position
}
