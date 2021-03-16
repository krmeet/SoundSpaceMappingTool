using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace GUI
{
	public class GuiFrame : GuiObject
	{
		public bool Visible = true;
		public int ZIndex = 0;
		public Color4 Colour = new Color4(1, 1, 1, 1);
		public bool MouseOver { get; protected set; }
		public GuiFrame() : base() { }
		public GuiFrame(Vector4 p, Vector4 s) : base(p, s) { }
		public override void Render(FrameEventArgs e)
		{
			if (Visible && Colour.A >= 0.05)
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