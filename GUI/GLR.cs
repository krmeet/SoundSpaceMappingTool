using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using SharpFont;
using SoundSpaceMappingTool;
namespace GUI
{
	public static class GLR
	{
		public static void RenderQuad(double x, double y, double width, double height, int z)
		{
			var size = MainWindow.Window.ClientSize;
			GL.Translate(x, y, z);
			GL.Scale(width, height, 1);
			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(0, 0);
			GL.Vertex2(0, 1);
			GL.Vertex2(1, 1);
			GL.Vertex2(1, 0);
			GL.End();
			GL.Scale(1f / width, 1f / height, 1);
			GL.Translate(-x, -y, -z);
		}
		public static void RenderImage(double x, double y, double width, double height, int z, int texture)
		{
			GL.BindTexture(TextureTarget.Texture2D, texture);
			var size = MainWindow.Window.ClientSize;
			GL.Translate(x, y, z);
			GL.Scale(width, height, 1);
			GL.Begin(PrimitiveType.Quads);
			GL.TexCoord2(0, 0);
			GL.Vertex2(0, 0);
			GL.TexCoord2(0, 1);
			GL.Vertex2(0, 1);
			GL.TexCoord2(1, 1);
			GL.Vertex2(1, 1);
			GL.TexCoord2(1, 0);
			GL.Vertex2(1, 0);
			GL.End();
			GL.Scale(1f / width, 1f / height, 1);
			GL.Translate(-x, -y, -z);
		}
		public static void RenderRect(RectangleF rect, int z)
		{
			RenderQuad(rect.X, rect.Y, rect.Width, rect.Height, z);
		}
		public static void RenderImageRect(RectangleF rect, int z, int texture)
		{
			RenderImage(rect.X, rect.Y, rect.Width, rect.Height, z, texture);
		}
		public static Color4 CombineColor4s(Color4 one, Color4 two)
		{
			Color4 newC = Color4.Black;
			newC = new Color4(
				(one.R + two.R) / 2f,
				(one.G + two.G) / 2f,
				(one.B + two.B) / 2f,
				(one.A + two.A) / 2f
			);
			return newC;
		}
	}
	public static class TextureManager // ah the joys of open sourced code. ty tom :^)
	{
		private static readonly Dictionary<string, int> Textures = new Dictionary<string, int>();
		public static int Get(string textureName)
		{
			if (Textures.TryGetValue(textureName, out var texId))
			{
				return texId;
			}
			return -1;
		}
		public static int GetOrRegister(string textureName, Bitmap bmp = null, bool smooth = false)
		{
			if (Textures.TryGetValue(textureName, out var texId))
				return texId;

			Bitmap img = bmp;

			if (img == null)
			{
				var file = textureName;

				if (!File.Exists(file))
				{
					return -1;
				}

				using (var fs = File.OpenRead(file))
				{
					img = (Bitmap)Image.FromStream(fs);
				}
			}

			var id = LoadTexture(img, smooth);

			Textures.Add(textureName, id);

			return id;
		}

		private static int LoadTexture(Bitmap img, bool smooth = false)
		{
			var id = GL.GenTexture();

			GL.BindTexture(TextureTarget.Texture2D, id);

			BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
				ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
				OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

			img.UnlockBits(data);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
				(int)(smooth ? TextureMinFilter.Linear : TextureMinFilter.Nearest));
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
				(int)(smooth ? TextureMagFilter.Linear : TextureMagFilter.Nearest));
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
				(int)TextureWrapMode.ClampToEdge);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
				(int)TextureWrapMode.ClampToEdge);

			return id;
		}
	}
	public class FontRenderer : IDisposable
	{
		private int FontSize;
		private Face FontFace;
		private Library Lib;
		public FontRenderer()
		{
			Lib = new Library();
			SetFont("content/fonts/UbuntuMono.ttf");
            SetSize(12);
		}
		public int GetStringLength(string str)
		{
			int length = 0;
			for (int i = 0; i < str.Length; i++)
			{
				char chr = str[i];
				uint glyph = FontFace.GetCharIndex(chr);
				FontFace.LoadGlyph(glyph, LoadFlags.Default, LoadTarget.Normal);
				length += (int)FontFace.Glyph.Metrics.Width;
			}
			return length;
		}
		private void SetFont(Face face)
		{
			FontFace?.Dispose();
			FontFace = face;
			SetSize(FontSize);
		}
		public void SetFont(string path)
		{
			SetFont(new Face(Lib, path));
		}
		public void SetSize(int size)
		{
			FontSize = size;
			FontFace?.SetCharSize(0, size, 0, 96);
		}
		public void Dispose()
		{
			Lib?.Dispose();
			FontFace?.Dispose();
			GC.SuppressFinalize(this);
		}
		~FontRenderer()
		{
			Console.WriteLine("FontRenderer leaked");
		}
	}
}