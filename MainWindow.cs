using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using GUI;
using OpenTK.Input;

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
            GL.Enable(EnableCap.AlphaTest);
			GL.BlendFunc(BlendingFactor.Src1Alpha, BlendingFactor.OneMinusSrcAlpha);
			base.OnLoad(e);
		}
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(ClientRectangle);
			GL.MatrixMode(MatrixMode.Projection);
			var m = Matrix4.CreateOrthographicOffCenter(0, Width, Height, 0, 0, 1);
			GL.LoadMatrix(ref m);
			Screen?.OnResize();
			OnRenderFrame(new FrameEventArgs());
		}
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
			GL.PushMatrix();
			Screen?.Render(e);
			GL.PopMatrix();
			SwapBuffers();
			base.OnRenderFrame(e);
		}
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			Title = $"Sound Space Mapping Tool - {Screen?.Name}";
			base.OnUpdateFrame(e);
		}
		protected override void OnUnload(EventArgs e)
		{
			Screen?.OnUnload();
			base.OnUnload(e);
		}
		protected override void OnMouseMove(MouseMoveEventArgs e)
		{
			Screen?.OnMouseMove(e);
			base.OnMouseMove(e);
		}
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			Screen?.OnMouseDown(e);
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			Screen?.OnMouseUp(e);
			base.OnMouseUp(e);
		}
	}
}