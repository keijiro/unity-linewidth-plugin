using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MeshGenerator : MonoBehaviour
{
    public int division = 200;
    Mesh mesh;
    Vector3[] vertices;
    float seed;

    // Awake: creates an empty line mesh.
    void Awake ()
    {
        mesh = new Mesh ();
        GetComponent<MeshFilter> ().sharedMesh = mesh;

        vertices = new Vector3[division];
        mesh.vertices = vertices;

        var indices = new int[division];
        for (var i = 0; i < division; i++)
        {
            indices [i] = i;
        }
        mesh.SetIndices (indices, MeshTopology.LineStrip, 0);

        seed = Random.value;
    }

    // Update: deforms the line mesh.
    void Update ()
    {
        for (var i = 0; i < division; i++)
        {
            var radius = Mathf.PerlinNoise (135.1f * i / division, Time.time * 0.6f + seed);
            vertices [i] = new Vector3 (
                Mathf.Sin (112.7f * i / division),
                Mathf.Sin (156.7f * i / division),
                Mathf.Sin (133.4f * i / division)
            ) * radius;
        }
        mesh.vertices = vertices;
    }
}
