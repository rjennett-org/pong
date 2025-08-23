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
        // Detect collision with walls and paddles
        // for (int i = 0; i < state.GetContactCount(); i++)
        // {
        //     // Reference the current Vector2 velocity
        //     Vector2 localVelocity = state.GetContactLocalVelocityAtPosition(0);

        //     // Case for each local normal, alter velocity
        //     Vector2 normal = state.GetContactLocalNormal(0);
        //     switch (normal)
        //     {
        //         case var value when value == Vector2.Up:
        //             Vector2 bounce = new Vector2(localVelocity.X, localVelocity.Y * -1);
        //             state.LinearVelocity = new Vector2(0, 0);
        //             ApplyCentralImpulse(bounce);
        //             break;
        //     }

        // }

        // Apply bounce based on collision normal
    }

    public void Launch()
    {
        ApplyCentralImpulse(newForce);
    }

}
