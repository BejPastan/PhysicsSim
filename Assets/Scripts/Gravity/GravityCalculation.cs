using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GravityCalculation
{
    public static Vector2 CalcForce(Vector2 pos1, Vector2 pos2, float mas1, float mas2)
    {
        float dist = Vector2.Distance(pos1, pos2);
        Vector2 force = (mas1 * mas2) / Mathf.Pow(dist, 2)*(pos2 - pos1).normalized;
        return force;
    }

}
