using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace GUI
{
	public class GuiFrame : GuiObject
	{
		protected bool OnScreen;
		public bool Visible = true;
		public int ZIndex = 0;
		public Color4 Colour = new Color4(255, 255, 255, 255);
		public bool MouseOver { get; protected set; }
		public GuiFrame() : base() { }
		public GuiFrame(Vector4 p, Vector4 s) : base(p, s) { }
		public override void Render(FrameEventArgs e)
		{
			OnScreen = (
				Rect.X + Rect.Width <= Window.ClientSize.Width &&
				Rect.Y + Rect.Height <= Window.ClientSize.Height &&
				Rect.X + Rect.Width >= 0 &&
				Rect.Y + Rect.Height >= 0
			);
			if (Visible && OnScreen)
			{
				GL.Color4(Colour);
				GLR.RenderRect(Rect, ZIndex);
				base.Render(e);
			}
		}
		public virtual void OnMouseEnter()
		{ }
		public virtual void OnMouseLeave()
		{ }
		public virtual void OnMouseMove()
		{ }
	}
}