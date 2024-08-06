using System;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SectorMirror : Indicator
{
    [SerializeField] SectorIndicator sectorIndicator;
    //Vector3[] vertices;
    //int[] triangles;
    //Mesh mesh;
    int x=1,y=1, z=-1;
    public override Mesh UpdateMesh(float maxDistance)
    {
        vertices = new Vector3[sectorIndicator.Vertices.Length];
        for (int i = 0; i < vertices.Length; i++) {
            vertices[i].x = sectorIndicator.Vertices[i].x * x;
            vertices[i].y = sectorIndicator.Vertices[i].y * y;
            vertices[i].z = sectorIndicator.Vertices[i].z * z;
        }
        mesh.vertices = vertices;
        return mesh;
    }

    Mesh CreateMesh()
    {
        mesh = new Mesh();
        //mesh.Clear();
        vertices = new Vector3[sectorIndicator.Vertices.Length];
        for (int i = 0; i < vertices.Length; i++) {
            vertices[i].x = sectorIndicator.Vertices[i].x * x;
            vertices[i].y = sectorIndicator.Vertices[i].y * y;
            vertices[i].z = sectorIndicator.Vertices[i].z * z;
        }
        Debug.Log("test !");
        triangles = sectorIndicator.Triangles;
        Array.Reverse(triangles);

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        return mesh;
    }
    private void Start()
    {
        GetComponent<MeshFilter>().mesh = CreateMesh();
    }
}
