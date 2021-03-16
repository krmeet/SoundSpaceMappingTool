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
			Frames.Add(new GuiFrame(new Vector4(0, 100, 0, 25), new Vector4(0, 0, 0, 0)));
		}
	}
}