using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SoundSpaceMappingTool
{
	public class MainWindow : GameWindow
	{
		public MainWindow(int width, int height, string title, VSyncMode vsync) : base()
		{
			Title = title;
			Width = width;
			Height = height;
			VSync = vsync;
			TargetUpdateFrequency = 20;
		}
		protected override void OnLoad(EventArgs e)
		{
			GL.ClearColor(0, 0, 0, 1);
			base.OnLoad(e);
		}
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);
			base.OnResize(e);
		}
		protected override void OnRenderFrame(FrameEventArgs args)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(0, 0);
			GL.Vertex2(50, 0);
			GL.Vertex2(50, 50);
			GL.Vertex2(0, 50);
			GL.End();

			Context.SwapBuffers();
			base.OnRenderFrame(args);
		}
	}
}