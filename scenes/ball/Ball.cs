using Godot;
using System;

public partial class Ball : RigidBody2D
{

    float initVelocity = 40;
    float maxVelocity = 60;

    public override void _Ready()
    {
    }

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        CustomIntegrator = false;

        if (state.GetContactCount() > 0)
        {
            if (((CharacterBody2D)state.GetContactColliderObject(0)).Name == "Paddle1" || ((CharacterBody2D)state.GetContactColliderObject(0)).Name == "Paddle2")
            {
                CustomIntegrator = true;

                // Get global position of collision
                Vector2 collisionPosition = state.GetContactColliderPosition(0);

                // Get global position of collider (Paddle)
                Node2D colliderObject = (Node2D)state.GetContactColliderObject(0);
                Vector2 colliderPosition = colliderObject.Position;

                // Use Y difference to calculate distance relative to collider
                // Positive = top of paddle
                // Negative = bottom of paddle
                var distanceFromPaddleCenter = colliderPosition.Y - collisionPosition.Y;

                // Calculate adjusted outgoing vector
                float outgoingAdjustment = distanceFromPaddleCenter * 6 * -1;

                // Apply only the adjustments to be made to the physics-based resultant vector
                Vector2 velocityOutgoing = new Vector2(0, outgoingAdjustment);

                // Apply impulse
                state.ApplyCentralImpulse(velocityOutgoing);

                // Limit max ball speed
                if (state.LinearVelocity.Length() > maxVelocity)
                {
                    // Calculate normal vector in original direction, multiply by max magnitude
                    state.LinearVelocity = state.LinearVelocity.Normalized() * maxVelocity;
                }
            }
        }
    }

    public void Launch()
    {
        Vector2 newForce = new Vector2(initVelocity, 0);
        ApplyCentralImpulse(newForce);
    }

}
