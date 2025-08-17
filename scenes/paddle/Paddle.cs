using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
    PackedScene ball;

    private int _speed = 300;

    public override void _Ready()
    {
        ball = ResourceLoader.Load<PackedScene>("res://scenes/ball/ball.tscn");

        // Instantiate ball scene
        Node2D ballInstance = ball.Instantiate<Node2D>();

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
    // Ball direction based on paddle collision position
}
