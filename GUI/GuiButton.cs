using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
namespace GUI
{
	public class GuiButton : GuiFrame
	{
		public string Text;
		private FontRenderer fr;
		public GuiButton() : base()
		{
			fr = new FontRenderer();
		}
		public GuiButton(Vector4 p, Vector4 s) : base(p, s)
		{
			fr = new FontRenderer();
		}
		private double Brightness = 0;
		public override void Render(FrameEventArgs e)
		{
			if (MouseOver)
			{
				if (Brightness < 1) Brightness += e.Time / 0.25;
				if (Brightness > 1) Brightness = 1;
			}
			else
			{
				if (Brightness > 0) Brightness -= e.Time / 2;
				if (Brightness < 0) Brightness = 0;
			}
			base.Render(e);
			if (Visible && OnScreen)
			{
				var brightener = GLR.CombineColor4s(Colour, new Color4((float)Brightness * 0.1f, (float)Brightness * 0.1f, (float)Brightness * 0.1f, 1f));
				var newRect = new RectangleF(Rect.X + 2, Rect.Y + 2, Rect.Width - 4, Rect.Height - 4);
				GL.Color4(brightener);
				GLR.RenderRect(newRect, ZIndex);
			}
		}
		public Action Mouse1Clicked;
		public Action Mouse2Clicked;
		public override void OnMouseClick(MouseButtonEventArgs e)
		{
			if (e.Button == MouseButton.Left) Mouse1Clicked.Invoke();
			if (e.Button == MouseButton.Right) Mouse2Clicked.Invoke();
			base.OnMouseClick(e);
		}
		public override void OnUnload()
		{
			fr?.Dispose();
			base.OnUnload();
		}
	}
}