using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeform : MonoBehaviour
{
    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;
    public float springForce = 20f;
    public float damping = 5f;
    float uniformScale = 1f;

    Vector3[] vertexVelocities;

    private void Start()
    {
        //get the mesh
        deformingMesh = GetComponent<MeshFilter>().mesh;
        //get verticies
        originalVertices = deformingMesh.vertices;
        //create new vertices based on 

        displacedVertices = new Vector3[originalVertices.Length];
        //for each vertici displace by i a
        for (int i = 0; i < originalVertices.Length; i++)
        {
            {
                displacedVertices[i] = originalVertices[i];
            }
        }

        vertexVelocities = new Vector3[originalVertices.Length];
    }

    private void Update()
    {
        //get the uniform scale
        uniformScale = transform.localScale.x;
        for (int i = 0;i < displacedVertices.Length;i++)
        {
            UpdateVertex(i);
        }
        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals();
    }

    void UpdateVertex(int i)
    {
        Vector3 velocity = vertexVelocities[i];
        Vector3 displacement = displacedVertices[i] - originalVertices[i];
        displacement *= uniformScale;
        velocity -= displacement * springForce * Time.deltaTime;
        velocity *= 1f - damping * Time.deltaTime;
        vertexVelocities[i] = velocity;
        displacedVertices[i] += velocity * (Time.deltaTime / uniformScale);
    }

    //add force to sphere
    public void AddDeformingForce(Vector3 point, float force)
    {
        point = transform.InverseTransformDirection(point);
        for (int i = 0;i < displacedVertices.Length;i++)
        {
            AddForceToVertex(i, point, force);
        }

        Debug.DrawLine(Camera.main.transform.position, point);
    }

    void AddForceToVertex(int i, Vector3 point, float force)
    {

        Vector3 pointToVertex = displacedVertices[i] - point;
        pointToVertex *= uniformScale;

        //get magnitude (drection of the vertici)
        float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
        float velocity = attenuatedForce * Time.deltaTime;
        vertexVelocities[i] += pointToVertex.normalized * velocity;
    }
}
