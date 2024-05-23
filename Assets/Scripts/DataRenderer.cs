using UnityEngine;

public static class DataRenderer
{
    
    
    public static void RenderVector(Vector3 pos, Vector3 dir)
    {
        Debug.DrawRay(pos, dir, Color.red);
    }

    public static void RenderBox(Vector2 bound1, Vector2 bound2, float time)
    {
        Debug.DrawLine(bound1, new Vector2(bound2.x, bound1.y), Color.green, time);
        Debug.DrawLine(bound1, new Vector2(bound1.x, bound2.y), Color.green, time);
        Debug.DrawLine(bound2, new Vector2(bound2.x, bound1.y), Color.green, time);
        Debug.DrawLine(bound2, new Vector2(bound1.x, bound2.y), Color.green, time);
    }


}
