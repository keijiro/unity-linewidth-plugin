#include <OpenGL/OpenGL.h>
#include <OpenGL/glu.h>

namespace
{
    float lineWidth = 1.0f;
}

extern "C" void UnityLineWidthPlugin_SetLineWidth(float width)
{
    lineWidth = width;
}

extern "C" void UnityRenderEvent(int eventID)
{
    if (eventID == 0)
    {
        glLineWidth(1.0f);
        glDisable(GL_LINE_SMOOTH);
    }
    else if (eventID == 1)
    {
        glLineWidth(lineWidth);
        glEnable(GL_LINE_SMOOTH);
    }
}
