using OpenTK;
namespace GUI
{
	public class GuiFrame : GuiObject
	{
		public GuiFrame() : base() { }
		public GuiFrame(Vector4 p, Vector4 s) : base(p, s) { }
		public override void Render(FrameEventArgs e)
		{
			GLR.RenderRect(Rect);
			base.Render(e);
		}
	}
}