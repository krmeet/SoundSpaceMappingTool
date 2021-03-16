using System;
using SoundSpaceMappingTool;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace GUI
{
	public class GuiObject
	{
		public Vector2 AbsPosition { get; private set; }
		public Vector2 AbsSize { get; private set; }
		public Vector4 Position;
		public Vector4 Size;
		private Rectangle Rect;
		protected MainWindow Window;
		public GuiObject()
		{
			Window = MainWindow.Window;
			Position = new Vector4();
			Size = new Vector4();
			AbsPosition = new Vector2();
			AbsSize = new Vector2();
			Rect = new Rectangle();
		}
		public GuiObject(Vector4 position, Vector4 size)
		{
			Position = position;
			Size = size;
			AbsPosition = new Vector2();
			AbsSize = new Vector2();
			Rect = new Rectangle();
		}
		public void Render(FrameEventArgs e)
		{ }
		public void OnResize()
		{
			var viewport = Window.ClientRectangle;
			var x = (int)(Position.X * viewport.Width) + (int)Position.Y;
			var y = (int)(Position.Z * viewport.Height) + (int)Position.W;
			int w = (int)(Size.X * viewport.Width) + (int)Size.Y;
			int h = (int)(Size.Z * viewport.Height) + (int)Size.W;
			AbsPosition = new Vector2(x, y);
			AbsSize = new Vector2(w, h);
			Rect = new Rectangle(x, y, w, h);
		}
	}
}