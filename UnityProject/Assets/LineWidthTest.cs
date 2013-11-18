using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class LineWidthTest : MonoBehaviour
{
    [Range(0.1f, 8.0f)]
    public float lineWidth = 1.5f;
    public int division = 200;
    
    Mesh mesh;
    Vector3[] vertices;

    [DllImport ("UnityLineWidthPlugin")]
    private static extern void UnityLineWidthPlugin_SetLineWidth (float width);

    // Awake: creates an empty line mesh.
    void Awake ()
    {
        mesh = new Mesh ();
        GetComponent<MeshFilter> ().sharedMesh = mesh;

        vertices = new Vector3[division];
        mesh.vertices = vertices;

        var indices = new int[division];
        for (var i = 0; i < division; i++) {
            indices [i] = i;
        }
        mesh.SetIndices (indices, MeshTopology.LineStrip, 0);
    }

    // Update: deforms the line mesh.
    void Update ()
    {
        for (var i = 0; i < division; i++) {
            vertices [i].Set (
                Mathf.Sin (312.7f * i / division),
                Mathf.PerlinNoise (235.1f * i / division, Time.time * 0.1f) * 2.0f - 1,
                Mathf.Sin (333.4f * i / division)
            );
        }
        mesh.vertices = vertices;
    }

    // Enables the line width before rendering the object.
    void OnRenderObject ()
    {
        UnityLineWidthPlugin_SetLineWidth (lineWidth);
        GL.IssuePluginEvent (1);
    }

    // Disables the line width after rendering the object.
    void OnPostRender ()
    {
        GL.IssuePluginEvent (0);
    }
}
