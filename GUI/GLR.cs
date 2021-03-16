using OpenTK;
using OpenTK.Graphics.OpenGL;
using SoundSpaceMappingTool;
namespace GUI
{
	public static class GLR
	{
		public static void RenderQuad(double x, double y, double width, double height)
		{
			var size = MainWindow.Window.ClientSize;
			GL.Translate(x, y, 0);
			GL.Scale(width, height, 1);
			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(0, 0);
			GL.Vertex2(0, 1);
			GL.Vertex2(1, 1);
			GL.Vertex2(1, 0);
			GL.End();
			GL.Scale(1f / width, 1f / height, 1);
			GL.Translate(-x, -y, 0);
		}
		public static void RenderRect(RectangleF rect)
		{
			RenderQuad(rect.X, rect.Y, rect.Width, rect.Height);
		}
	}
}