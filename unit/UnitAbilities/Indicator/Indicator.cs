using System;
using Unity.Jobs;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public abstract class Indicator :MonoBehaviour
{
    protected Mesh mesh;
    protected Vector3[] vertices;
    protected int[] triangles;
    protected int segments = 20;
    [SerializeField] protected UnityEngine.GameObject AbilityRangePrefab;
    [SerializeField] protected float maxRange = 10;
    [SerializeField] protected int area = 2;

    public virtual Vector2 LimitTheMaximumRange(Vector2 targetPosition, Vector2 casterPosition)
    {
        Vector2 maxV;
        var range = (targetPosition - casterPosition).magnitude;
        if (range >= maxRange) {     
            maxV = (targetPosition-casterPosition).normalized * maxRange;
        }
        else {
            maxV = targetPosition-casterPosition;           
        }
        return maxV;
    }
    public abstract Mesh UpdateMesh(float maxDistance);
    //private void OnDrawGizmos()
    //{
    //    if (vertices == null)
    //        return;
    //    for (int i = 0; i < vertices.Length; i++) {
    //        Gizmos.DrawSphere(vertices[i], 0.2f);
    //        Gizmos.color = Color.yellow;
    //    }
    //}
  
}

