using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoftBodyElement
{
    [SerializeField]
    Transform transform;

    [SerializeField]
    public Vector2 position;
    [SerializeField]
    float radius;
    [SerializeField]
    public float mass { get; private set;}

    [SerializeField]
    Vector2 velocity;
    [SerializeField]
    Vector2 force;

    public SoftBodyElement(Transform transform, Vector2 position, float radius, float mass)
    {
        this.transform = transform;
        this.position = position;
        this.radius = radius;
        ChangeSize();
        transform.position = position;
        this.mass = mass;
    }

    private void ChangeSize()
    {
        transform.localScale = 2 * radius * Vector3.one;
    }

    public void UpdateForce(Vector2 force)
    {
        this.force += force;
    }

    public void CalcVelocity(float timeStamp)
    {
        velocity += timeStamp * force / mass;
        force = Vector2.zero;
    }

    public void UpdatePosition(float timeStamp)
    {
        position += timeStamp * velocity;
        transform.position = position;
        //check if the element is out of bounds
        if (position.x > SoftBodySimulationController.instance.boundsWidth)
        {
            position.x = SoftBodySimulationController.instance.boundsWidth;
            velocity.x = -velocity.x;
        }
        if (position.x < -SoftBodySimulationController.instance.boundsWidth)
        {
            position.x = -SoftBodySimulationController.instance.boundsWidth;
            velocity.x = -velocity.x;
        }
        if (position.y > SoftBodySimulationController.instance.boundsHeight)
        {
            position.y = SoftBodySimulationController.instance.boundsHeight;
            velocity.y = -velocity.y;
        }
        if (position.y < -SoftBodySimulationController.instance.boundsHeight)
        {
            position.y = -SoftBodySimulationController.instance.boundsHeight;
            velocity.y = -velocity.y;
        }
    }
}
