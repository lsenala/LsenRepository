using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleIndicator : Indicator
{
    float radius;
    private void Start()
    {
        GetComponent<MeshFilter>().mesh = CreatMesh();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
    public Mesh CreatMesh() {
        mesh = new Mesh();
        mesh.Clear();
        vertices = new Vector3[4];
        float angInit = Mathf.Atan((area / maxRange) / maxRange);
        //=Mathf.Acos((.5f*maxRange) / maxRadius);
        radius = Mathf.Cos(angInit) * (.5f * maxRange);
        float testAng = angInit * Mathf.Rad2Deg;
        //Debug.Log(testAng);
        float temp1 = 0*Mathf.Deg2Rad,temp2=540*Mathf.Deg2Rad;          
        for (int i = 0; i < vertices.Length; i++) {
            //0 180+temp   1 360-temp 2 360+temp  3  180-temp
            float ang ;
            if (i % 2 == 0) {
                temp1 += 180 * Mathf.Deg2Rad;
                ang = temp1 + angInit;
                float test1 = ang * Mathf.Rad2Deg;
                //Debug.Log(test1);
            }
            else {
                temp2 -= 180 * Mathf.Deg2Rad;
                ang = temp2 - angInit;
                float test2 = ang * Mathf.Rad2Deg;
                //Debug.Log(test2);
            }
            float test=ang*Mathf.Rad2Deg;
            //Debug.Log(test);
            float cosA = Mathf.Cos(ang);
            float sinA = Mathf.Sin(ang);

            vertices[i] = new Vector3(radius * cosA, 0,radius * sinA);

            //Debug.Log("vertices " + i + " " + vertices[i]);
            vertices[i] = vertices[i] + new Vector3(.5f*maxRange, 0, 0);
        }
        triangles = new int[] { 0, 2, 1, 0, 3, 2 };
    
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //Debug.Log(mesh.vertexCount);
        return mesh;
    }
    public override Mesh UpdateMesh(float maxDistance)
    {
        float angCur = Mathf.Acos((area / maxDistance) /(2* radius));
        float temp1 = 0 * Mathf.Deg2Rad, temp2 = 540 * Mathf.Deg2Rad;
        for (int i = 0; i < vertices.Length; i++) {
            float ang;
            if (i % 2 == 0) {
                temp1 += 180 * Mathf.Deg2Rad;
                ang = temp1 + angCur;
                float test1 = ang * Mathf.Rad2Deg;
                //Debug.Log(test1);
            }
            else {
                temp2 -= 180 * Mathf.Deg2Rad;
                ang = temp2 - angCur;
                float test2 = ang * Mathf.Rad2Deg;
                //Debug.Log(test2);
            }
            float test = ang * Mathf.Rad2Deg;
            //Debug.Log(test);
            float cosA = Mathf.Cos(ang);
            float sinA = Mathf.Sin(ang);

            vertices[i] = new Vector3(radius * cosA, 0, radius * sinA);

            //Debug.Log("vertices " + i + " " + vertices[i]);
            vertices[i] = vertices[i] + new Vector3(.5f * maxRange, 0, 0);
            
            mesh.vertices= vertices;
        }
            return mesh;
    }

}
