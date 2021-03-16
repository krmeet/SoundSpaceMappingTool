using GUI;
using OpenTK;
namespace SoundSpaceMappingTool
{
	public class ProjectSelection : GuiScreen
	{
		public static ProjectSelection Screen { get; private set; }
		public ProjectSelection() : base()
		{
			Name = "Project Selection";
			Screen = this;
			var testFrame = new GuiFrame(new Vector4(0.5f, 0, 0, 10), new Vector4(0, 100, 0, 25));
			Frames.Add(testFrame);
		}
		public override void Render(FrameEventArgs e)
		{
			base.Render(e);
		}
	}
}