using UnityEngine;

public static class DataRenderer
{
    public static void RenderVector(Vector3 pos, Vector3 dir)
    {
        Debug.DrawRay(pos, dir, Color.red);
    }
}
