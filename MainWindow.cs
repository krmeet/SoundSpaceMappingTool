using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using GUI;

namespace SoundSpaceMappingTool
{
	public class MainWindow : GameWindow
	{
		public static MainWindow Window;
		private GuiScreen Screen;
		public MainWindow(int width, int height, string title, VSyncMode vsync) : base()
		{
			Window = this;
			Title = title;
			Width = width;
			Height = height;
			VSync = vsync;
			TargetUpdateFrequency = 20;

			// initialise uis
			new ProjectSelection();

			Run();
		}
		protected override void OnLoad(EventArgs e)
		{
			Screen = ProjectSelection.Screen;
			GL.ClearColor(new Color4(0.1f, 0.1f, 0.125f, 1f));
			base.OnLoad(e);
		}
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);
			Screen.OnResize();
			base.OnResize(e);
		}
		protected override void OnRenderFrame(FrameEventArgs args)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			Screen.Render(args);

			Context.SwapBuffers();
			base.OnRenderFrame(args);
		}
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			Title = $"Sound Space Mapping Tool - {Screen.Name}";
			base.OnUpdateFrame(e);
		}
	}
}