#include <OpenGL/OpenGL.h>
#include <OpenGL/glu.h>

extern "C" void UnityLineWidthPlugin_Initialize()
{
    // Do nothing!
}

extern "C" void UnityRenderEvent(int eventID)
{
    if (eventID == 0)
    {
        glLineWidth(1.0f);
        glDisable(GL_LINE_SMOOTH);
    }
    else
    {
        glLineWidth(0.01f * eventID);
        glEnable(GL_LINE_SMOOTH);
    }
}
