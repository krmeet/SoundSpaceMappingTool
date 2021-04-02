using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;
namespace GUI
{
	public class GuiButton : GuiFrame
	{
        public string Text;
        public string Font
        {
            get { return fr?.Font; }
            set
            {
                fr?.SetFont(value);
            }
        }
        private FontRenderer fr;
		public GuiButton() : base()
		{
			fr = new FontRenderer();
		}
		public GuiButton(Vector4 p, Vector4 s) : base(p, s)
		{
            fr = new FontRenderer();
		}
		private float Brightness = 0;
		public override void Render(FrameEventArgs e)
		{
			if (MouseOver)
			{
				if (Brightness < 1) Brightness += (float)(e.Time / 0.25);
				if (Brightness > 1) Brightness = 1;
			}
			else
			{
				if (Brightness > 0) Brightness -= (float)(e.Time / 2);
				if (Brightness < 0) Brightness = 0;
			}
			base.Render(e);
			if (Visible && OnScreen)
			{
                var diffR = (1f - Colour.R)*0.75f;
                var diffG = (1f - Colour.G)*0.75f;
                var diffB = (1f - Colour.B)*0.75f;
                var brightener = new Color4(1f, 1f, 1f, Brightness*0.4f);
				var newRect = new RectangleF(Rect.X + 2, Rect.Y + 2, Rect.Width - 4, Rect.Height - 4);
				GL.Color4(brightener);
				GLR.RenderRect(newRect, ZIndex);
			}
            GL.Color4(Color4.Transparent);
            fr?.RenderString(Text, new Point((int)Rect.X, (int)Rect.Y));
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