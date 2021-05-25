using System;
using System.Drawing;
using GUI;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace SoundSpaceMappingTool
{
	public class ProjectSelection : GuiScreen
	{
        private int mmm;
		public static ProjectSelection Screen { get; private set; }
		public ProjectSelection() : base()
		{
            mmm = TextureManager.GetOrRegister("mmm.jpg", new Bitmap("content/mmm.jpg"), true);
			Name = "Project Selection";
			Screen = this;
            GuiFrame testFrame = new GuiFrame(new Vector4(0.5f, 0, 0, 10), new Vector4(0, 200, 0, 200))
            {
                Colour = Color4.Gray
            };
            GuiFrame otherFrame = new GuiFrame(new Vector4(1, -25, 0, 0), new Vector4(0, 100, 0, 100))
            {
                Colour = Color4.Red,
                Image = "mmm.jpg"
            };
            GuiButton button = new GuiButton(new Vector4(0, -100, 0.5f, 0), new Vector4(0, 100, 0, 25))
            {
                Colour = Color4.Orange,
                Text = "abc 123 abc123"
            };
            Children.Add(testFrame);
			testFrame.Children.Add(otherFrame);
			testFrame.Children.Add(button);
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
		public override void OnUnload()
		{
			base.OnUnload();
		}
	}
}