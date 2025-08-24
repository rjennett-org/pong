using Godot;
using System;

public partial class Ball : RigidBody2D
{

    Vector2 newForce = new Vector2(40, 0);

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

                // Override outgoing vector after collision
                // Get collision vector
                Vector2 velocityIncoming = state.GetContactLocalVelocityAtPosition(0);

                // Calculate adjusted outgoing vector
                Vector2 velocityOutgoing = new Vector2(velocityIncoming.X * -1, velocityIncoming.Y + distanceFromPaddleCenter);

                // Apply impulse
                state.ApplyCentralImpulse(velocityOutgoing);
            }
        }
    }

    public void Launch()
    {
        ApplyCentralImpulse(newForce);
    }

}
