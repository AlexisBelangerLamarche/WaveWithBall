using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobble : MonoBehaviour
{
    public float a;
    public float b;
    public float speedx;
    public float speedz;
    public MeshFilter WaveMesh;
    Vector3[] verticies;

    private void Start()
    {

    }

    float itex;
    float itez;
    private void Update()
    {
        List<Vector3> newVerticies = new List<Vector3>();
        verticies = WaveMesh.mesh.vertices;
        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = a * Mathf.Sin(b * (verticies[i].x + itex)) + a * Mathf.Sin(b * (verticies[i].z + itez));
            newVerticies.Add(verticies[i]);
        }
        WaveMesh.mesh.SetVertices(newVerticies);
        WaveMesh.GetComponent<MeshCollider>().sharedMesh = WaveMesh.mesh;

        itex += speedx * Time.deltaTime;
        itez += speedz * Time.deltaTime;
    }
}
