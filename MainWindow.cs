using System;
using OpenTK;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace SoundSpaceMappingTool
{
	public class MainWindow : GameWindow
	{
		public MainWindow(int width, int height, string title, VSyncMode vsync) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
		{
			Title = title;
			Size = new Vector2i(width, height);
			VSync = vsync;
		}
		protected override void OnLoad()
		{
			GL.ClearColor(0, 0, 0, 1);
			base.OnLoad();
		}
		protected override void OnResize(ResizeEventArgs e)
		{
			GL.Viewport(0, 0, Size.X, Size.Y);
			base.OnResize(e);
		}
		protected override void OnRenderFrame(FrameEventArgs args)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			Context.SwapBuffers();
			base.OnRenderFrame(args);
		}
	}
}