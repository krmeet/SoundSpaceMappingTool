using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace GUI
{
	public class GuiFrame : GuiObject
	{
		public int ZIndex = 0;
		public Color4 Colour = new Color4(1, 1, 1, 1);
		public GuiFrame() : base() { }
		public GuiFrame(Vector4 p, Vector4 s) : base(p, s) { }
		public override void Render(FrameEventArgs e)
		{
			GL.Color4(Colour);
			GLR.RenderRect(Rect, ZIndex);
			base.Render(e);
		}
	}
}