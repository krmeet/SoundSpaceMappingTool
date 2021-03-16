using GUI;
namespace SoundSpaceMappingTool
{
	public class ProjectSelection : GuiScreen
	{
		public static ProjectSelection Screen { get; private set; }
		public ProjectSelection() : base()
		{
			Name = "Project Selection";
			Screen = this;
		}
	}
}