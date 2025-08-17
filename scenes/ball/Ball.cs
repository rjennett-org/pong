using Godot;
using System;

public partial class Ball : RigidBody2D
{

    Vector2 newForce = new Vector2(2, 2);

    public override void _Ready()
    {
    }


    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        // Detect collision with walls and paddles
        // Apply bounce based on collision normal
    }


}
