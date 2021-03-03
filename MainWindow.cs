using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace SoundSpaceMappingTool
{
    public class MainWindow : GameWindow
    {
        public MainWindow(int width, int height, string title, VSyncMode vsync) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.Title = title;
            this.VSync = vsync;
            this.RenderFrame += new Action<FrameEventArgs>(Render);
        }
        public void Render(FrameEventArgs args)
        {
            GL.ClearColor(0,0,0,1);
        }
    }
}