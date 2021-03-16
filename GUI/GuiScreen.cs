using System.Collections.Generic;
using OpenTK;
namespace GUI
{
	public class GuiScreen : GuiObject
	{
		public string Name { get; protected set; } = "Untitled";
		protected List<GuiFrame> Frames = new List<GuiFrame> { };
		public override void Render(FrameEventArgs e)
		{
			foreach (GuiFrame frame in Frames)
			{
				frame.Render(e);
			}
			base.Render(e);
		}
		public override void OnResize()
		{
			foreach (GuiFrame frame in Frames)
			{
				frame.OnResize();
			}
			base.OnResize();
		}
	}
}