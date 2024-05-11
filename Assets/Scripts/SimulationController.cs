using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    [SerializeField]
    int objectCount = 5;
    [SerializeField]
    float objectRadius = 0.2f;
    [SerializeField]
    [Range(0, 10)]
    float maxMass;
    [SerializeField]
    [Range(0, 10)]
    float minMass;

    List<GravityObject> gravityObjects = new();

    private void Start()
    {
        for(int i = 0; i < objectCount; i++)
        {
            Transform newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
            gravityObjects.Add(new GravityObject(Random.Range(minMass, maxMass), new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), newObject, objectRadius));
        }
    }

    private void Update()
    {
        for (int i = 0; i < gravityObjects.Count; i++)
        {
            Vector2 force = Vector2.zero;
            for (int j = i + 1; j < gravityObjects.Count; j++)
            {
                if (!InRange(gravityObjects[i], gravityObjects[j]))
                {
                    continue;
                }
                force = GravityCalculation.CalcForce(gravityObjects[i].position, gravityObjects[j].position, gravityObjects[i].mass, gravityObjects[j].mass);
                gravityObjects[j].UpdateForce(-force);
                gravityObjects[i].UpdateForce(force);
            }
        }

        foreach (GravityObject gravityObject in gravityObjects)
        {
            gravityObject.UpdateVelocity(Time.deltaTime);
            DataRenderer.RenderVector(gravityObject.position, gravityObject.velocity);
        }
    }

    

    private bool InRange(GravityObject obj1, GravityObject obj2)
    {
        float dist = Vector2.Distance(obj1.position, obj2.position);
        if(dist < obj1.impactRadius && dist < obj2.impactRadius)
        {
            if(obj1.radius<dist && obj2.radius < dist)
            {
                return true;
            }
        }
        return false;
    }
}
