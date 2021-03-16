using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace GUI
{
	public class GuiScreen : GuiObject
	{
		public string Name { get; protected set; } = "Untitled";
		public new void Render(FrameEventArgs e)
		{
			base.Render(e);
		}
	}
}