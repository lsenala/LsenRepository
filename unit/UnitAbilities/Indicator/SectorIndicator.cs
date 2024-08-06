using UnityEngine;
public class SectorIndicator : Indicator
{
    
    public Vector3[] Vertices { get { return vertices; } private set { vertices = value; } }
    public int[] Triangles { get { return triangles; } private set { triangles = value; } }

    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = CreatMesh(maxRange, area);
    }
    public Mesh CreatMesh(float radius, int area)
    {
        float temp = 0;
        float centralAngleRad = 2 * area / (Mathf.Pow(radius, 2)); /* Mathf.Rad2Deg;*/
        float halfCentralAngleRad = centralAngleRad / 2;
        int vertices_count = segments + 1;
        vertices = new Vector3[vertices_count];
        vertices[0] = Vector3.zero;
        mesh = new Mesh();
        for (int i = 1; i < vertices_count; i++) {
            float cosA = Mathf.Cos(temp);
            float sinA = Mathf.Sin(temp);
            vertices[i] = new Vector3(radius * cosA, 0, radius * sinA);
            temp += halfCentralAngleRad / (vertices_count / 2);//可能是segments/2;
            if (temp > 180*Mathf.Deg2Rad)
                break;
        }
        int triangle_count = segments * 3;
        triangles = new int[triangle_count];
        for (int i = 0, vi = 1; i <= (triangle_count - 1); i += 3, vi++) {
            triangles[i] = 0;
            triangles[i + 2] = vi ;
            triangles[i + 1] = vi+1;
        }
        triangles[triangle_count - 3] = 0;
        triangles[triangle_count - 2] = vertices_count - 1;
        triangles[triangle_count - 1] = 1;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        return mesh;
    }
    public override Mesh UpdateMesh(float maxDistance)
    {
        float temp = 0;
        float centralAngleRad = 2 * area / (Mathf.Pow(maxDistance, 2)); /* Mathf.Rad2Deg;*/
        float halfCentralAngleRad = centralAngleRad / 2;
        int vertices_count = segments + 1;
        vertices = new Vector3[vertices_count];
        vertices[0] = Vector3.zero;
        for (int i = 1; i < vertices_count; i++) {
            float cosA = Mathf.Cos(temp);
            float sinA = Mathf.Sin(temp);
            vertices[i] = new Vector3(maxDistance * cosA, 0, maxDistance * sinA);
            temp += halfCentralAngleRad / (vertices_count / 2);//可能是segments/2;
            if (temp > 180 * Mathf.Deg2Rad)
                break;
        }
        //int triangle_count = segments * 3;
        //triangles = new int[triangle_count];
        //for (int i = 0, vi = 1; i <= (triangle_count - 1); i += 3, vi++) {
        //    triangles[i] = 0;
        //    triangles[i + 2] = vi;
        //    triangles[i + 1] = vi + 1;
        //}
        //triangles[triangle_count - 3] = 0;
        //triangles[triangle_count - 2] = vertices_count - 1;
        //triangles[triangle_count - 1] = 1;

        mesh.vertices = vertices;
        //mesh.triangles = triangles;

        return mesh;
    }
}
