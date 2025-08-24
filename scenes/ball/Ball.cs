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
        if (state.GetContactCount() > 0)
        {
            // Get global position of collision
            Vector2 collisionPosition = state.GetContactColliderPosition(0);

            // Get global position of collider (Paddle)
            Node2D colliderObject = (Node2D)state.GetContactColliderObject(0);
            Vector2 colliderPosition = colliderObject.Position;

            // Use Y difference to calculate distance relative to collider
            // Positive = top of paddle
            // Negative = bottom of paddle
            var distanceFromPaddleCenter = colliderPosition.Y - collisionPosition.Y;
        }
    }

    public void Launch()
    {
        ApplyCentralImpulse(newForce);
    }

}
