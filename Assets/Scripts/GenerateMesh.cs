using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GenerateMesh : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh =new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(1,1,0),
            new Vector3(0,2,0),
            new Vector3(1,2,0),
            new Vector3(0,3,0),
            new Vector3(1,3,0),
        };

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2,
            1, 4, 3,
            4, 5, 3,
            4, 6, 5,
            6, 7, 5

        };
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

}
