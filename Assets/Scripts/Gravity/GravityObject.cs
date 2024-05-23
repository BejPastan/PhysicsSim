using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class GravityObject
{
    [SerializeField]
    public float mass ;/*{ get; private set;}*/
    [SerializeField]
    public float impactRadius ;/*{ get; private set;}*/
    [SerializeField]
    public Vector2 position ;/*{ get; private set;}*/
    [SerializeField]
    public Vector2 velocity ;/*{ get; private set;}*/
    [SerializeField]
    public Vector2 force ;/*{ get; private set;}*/
    [SerializeField]
    public Transform transform ;/*{ get; private set;}*/
    [SerializeField]
    public float radius ;/*{ get; private set;}*/

    public GravityObject(float mass, Vector2 position, Transform transform, float radius)
    {
        this.mass = mass;
        this.position = position;
        this.velocity = Vector2.zero;
        this.transform = transform;
        this.transform.position = position;
        this.radius = radius;
        CalcImpactRadius();
        CalcSize();
    }

    private void CalcImpactRadius()
    {
        impactRadius += Mathf.Sqrt(mass) / 0.1f;
    }

    private void CalcSize()
    {
        transform.localScale = Vector3.one * radius * 2;
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

    public void Combine(float radius, float mass, Vector2 velocity)
    {
        this.velocity += (this.velocity * this.mass) + (velocity * mass);
        this.mass += mass;
        this.velocity /= mass;
        this.radius = Mathf.Pow(Mathf.Pow(radius, 3) + Mathf.Pow(this.radius, 3), 1f / 3f);
        CalcSize();
        Debug.Log("Position" + position);

    }

    public void Remove()
    {
        GameObject.Destroy(transform.gameObject);
    }
}
