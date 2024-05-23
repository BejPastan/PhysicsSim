using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SoftBodySimulationController : MonoBehaviour
{
    public static SoftBodySimulationController instance;


    [SerializeField]
    public int boundsWidth;
    [SerializeField]
    public int boundsHeight;

    [SerializeField]
    [Range(1, 100)]
    int softBodyWidth = 10;
    [SerializeField]
    [Range(1, 100)]
    int softBodyHeight = 10;

    [SerializeField]
    SoftBodyElement[,] elements;

    [SerializeField]
    float startDist = 0.5f;
    [SerializeField]
    float radius = 0.2f;

    private void Start()
    {
        instance = this;
        SpawnSoftBody();
        DataRenderer.RenderBox(new Vector2(-boundsWidth, -boundsHeight), new Vector2(boundsWidth, boundsHeight), float.MaxValue);
    }

    public void SpawnSoftBody()
    {      
       elements = new SoftBodyElement[softBodyWidth, softBodyHeight];
        
        for(int y =-softBodyHeight/2; y< softBodyHeight/2; y++) 
        {
            for(int x =-softBodyWidth/2; x< softBodyWidth/2; x++)
            {
                Transform newObject = GameObject.CreatePrimitive(PrimitiveType.Quad).transform;
                elements[x+softBodyWidth/2, y+softBodyHeight/2] = new SoftBodyElement(newObject, new Vector2(x, y) * startDist, radius, 1);
            }
        }
    }

    private void FixedUpdate()
    {
       for(int y = 0; y< softBodyHeight; y++)
       {
           for(int x = 0; x< softBodyWidth; x++)
           {
                //gravity force
                float multiplier = 9.81f * elements[x, y].mass;
                Vector2 force = new Vector2(0, -multiplier);
                elements[x, y].UpdateForce(force);
           }
       }

       for(int y = 0; y< softBodyHeight; y++)
       {
            for(int x = 0; y< softBodyWidth; y++)
            {
                for(int i = -1; i<=1; i++)
                {
                    for(int j = 0; j<=1; j++)
                    {
                        if(i == 0 && j == 0)
                        {
                            continue;
                        }
                        if(x+i >= 0 && x+i < softBodyWidth && y+j >= 0 && y+j < softBodyHeight)
                        {
                            //calc force that impact from the neighbour
                        }
                    }
                }
            }
       }

        foreach (SoftBodyElement element in elements)
       {
            element.CalcVelocity(Time.fixedDeltaTime);
            element.UpdatePosition(Time.fixedDeltaTime);
       }
    }


}
