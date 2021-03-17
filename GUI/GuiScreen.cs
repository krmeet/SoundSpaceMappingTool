using System.Collections.Generic;
using OpenTK;
namespace GUI
{
	public class GuiScreen : GuiObject
	{
		public string Name { get; protected set; } = "Untitled";
		public List<GuiFrame> Children { get; protected set; } = new List<GuiFrame> { };
		public GuiScreen() : base()
		{
			Position = new Vector4();
			Size = new Vector4(1, 0, 1, 0);
		}
		public GuiScreen(Vector4 p, Vector4 s) : base(p, s)
		{
		}
		public override void Render(FrameEventArgs e)
		{
			foreach (GuiFrame frame in Children)
			{
				frame.Parent = this;
				frame.Render(e);
			}
			base.Render(e);
		}
		public override void OnResize()
		{
			foreach (GuiFrame frame in Children)
			{
				frame.OnResize();
			}
			base.OnResize();
		}
	}
}