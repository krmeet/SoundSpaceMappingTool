using System;
using GUI;
using OpenTK;
using OpenTK.Graphics;
namespace SoundSpaceMappingTool
{
	public class ProjectSelection : GuiScreen
	{
		public static ProjectSelection Screen { get; private set; }
		public ProjectSelection() : base()
		{
			Name = "Project Selection";
			Screen = this;
			var testFrame = new GuiFrame(new Vector4(0.5f, 0, 0, 10), new Vector4(0, 200, 0, 200));
			testFrame.Colour = Color4.Gray;
			var otherFrame = new GuiFrame(new Vector4(1, -25, 0, 0), new Vector4(0, 100, 0, 100));
			otherFrame.Colour = Color4.Red;
			var button = new GuiButton(new Vector4(1, -25, 0.5f, 0), new Vector4(0, 100, 0.25f, 25));
			button.Colour = Color4.Black;
			button.Text = "abc";
			Children.Add(testFrame);
			testFrame.Children.Add(otherFrame);
			otherFrame.Children.Add(button);
			button.Mouse1Clicked += doThing;
		}
		private void doThing()
		{
			Console.WriteLine("Thing done");
		}
		public override void Render(FrameEventArgs e)
		{
			base.Render(e);
		}
	}
}