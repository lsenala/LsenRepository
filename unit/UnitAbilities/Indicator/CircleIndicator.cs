using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleIndicator : Indicator
{
    [SerializeField] float maxRadius;
    Mesh CreatMesh()
    {
        float temp = 0;
        mesh = new Mesh();
        mesh.Clear();
        int vertices_count = segments + 1;
        vertices = new Vector3[vertices_count];
        vertices[0] = Vector3.zero;
        float CentralAngleRad = 360 * Mathf.Deg2Rad;
        mesh = new Mesh();
        for (int i = 1; i < vertices_count; i++) {
            float cosA = Mathf.Cos(temp);
            float sinA = Mathf.Sin(temp);
            vertices[i] = new Vector3(maxRadius * cosA, 0, maxRadius * sinA);
            temp += CentralAngleRad / segments ;
        }
        int triangle_count = segments * 3;
        triangles = new int[triangle_count];
        for (int i = 0, vi = 1; i <= triangle_count-1 ; i += 3, vi++) {
            triangles[i] = 0;
            triangles[i + 2] = vi ;
            triangles[i + 1] = vi+1;
        }
        triangles[triangle_count - 3] = 0;
        triangles[triangle_count - 1] = vertices_count - 1;
        triangles[triangle_count - 2] = 1;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        return mesh;
    }
    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = CreatMesh();
    }
    public override Mesh UpdateMesh(float maxDistance)
    {
        return mesh;
    }
}
