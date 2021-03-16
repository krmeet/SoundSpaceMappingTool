using SoundSpaceMappingTool;
using OpenTK;
namespace GUI
{
	public class GuiObject
	{
		public Vector2 AbsPosition { get; private set; }
		public Vector2 AbsSize { get; private set; }
		public Vector4 Position;
		public Vector4 Size;
		protected RectangleF Rect;
		protected MainWindow Window;
		public GuiObject()
		{
			Window = MainWindow.Window;
			Position = new Vector4();
			Size = new Vector4();
			AbsPosition = new Vector2();
			AbsSize = new Vector2();
			Rect = new RectangleF();
		}
		public GuiObject(Vector4 position, Vector4 size)
		{
			Window = MainWindow.Window;
			Position = position;
			Size = size;
			AbsPosition = new Vector2();
			AbsSize = new Vector2();
			Rect = new RectangleF();
			OnResize();
		}
		public virtual void Render(FrameEventArgs e)
		{ }
		public virtual void OnResize()
		{
			var viewport = Window.ClientRectangle;
			var center = new PointF(viewport.Width / 2, viewport.Height / 2);
			var x = (int)(Position.X * viewport.Width) + (int)Position.Y;
			var y = (int)(Position.Z * viewport.Height) + (int)Position.W;
			int w = (int)(Size.X * viewport.Width) + (int)Size.Y;
			int h = (int)(Size.Z * viewport.Height) + (int)Size.W;
			AbsPosition = new Vector2(x, y);
			AbsSize = new Vector2(w, h);
			Rect = new RectangleF(x, y, w, h);
		}
	}
}