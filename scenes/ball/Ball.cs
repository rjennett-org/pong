using Godot;
using System;

public partial class Ball : RigidBody2D
{

    Vector2 newForce = new Vector2(40, 40);

    public override void _Ready()
    {
    }

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
    }

    public void Launch()
    {
        ApplyCentralImpulse(newForce);
    }

}
