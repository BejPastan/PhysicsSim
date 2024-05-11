using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject
{
    public float mass { get; private set;}
    public float impactRadius { get; private set;}
    public Vector2 position { get; private set;}
    public Vector2 velocity { get; private set;}
    public Vector2 force { get; private set;}
    public Transform transform { get; private set;}
    public float radius { get; private set;}

    public GravityObject(float mass, Vector2 position, Transform transform, float radius)
    {
        this.mass = mass;
        this.position = position;
        this.velocity = Vector2.zero;
        impactRadius = Mathf.Sqrt(mass) / 0.1f;
        this.transform = transform;
        this.transform.position = position;
        this.transform.localScale = new Vector3(radius, radius, radius);
        this.radius = radius;
    }

    public void UpdateForce(Vector2 newForce)
    {
        force+=newForce;
    }

    public void UpdateVelocity(float timeStep)
    {
        velocity += (force/mass) * timeStep;
        UpdatePosition(timeStep);
        force = Vector2.zero;
    }

    private void UpdatePosition(float timeStep)
    {
        position += velocity * timeStep;
        transform.position = position;
    }
}
