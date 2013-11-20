using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class AALineEffects : MonoBehaviour
{
    [Range(0.01f, 10.0f)]
    public float
        lineWidth = 1.5f;

    [DllImport ("UnityLineWidthPlugin")]
    private static extern void UnityLineWidthPlugin_Initialize ();

    // Enables the line width before rendering the scene.
    void OnPreRender ()
    {
        UnityLineWidthPlugin_Initialize ();
        GL.IssuePluginEvent ((int)(lineWidth * 100));
    }

    // Disables the line width after rendering the scene
    void OnPostRender ()
    {
        GL.IssuePluginEvent (0);
    }
}
