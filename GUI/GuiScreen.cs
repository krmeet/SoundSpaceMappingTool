using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
namespace GUI
{
	public class GuiScreen : GuiObject
	{
		public string Name { get; protected set; } = "Untitled";
		public List<GuiFrame> Children { get; protected set; } = new List<GuiFrame> { };
		public GuiScreen() : base()
		{
			Position = new Vector4();
			Size = new Vector4(1, 0, 1, 0);
		}
		public GuiScreen(Vector4 p, Vector4 s) : base(p, s)
		{
		}
		public override void Render(FrameEventArgs e)
		{
			foreach (GuiFrame frame in Children)
			{
				frame.Parent = this;
				frame.Render(e);
			}
			base.Render(e);
		}
		public virtual void OnMouseMove(MouseMoveEventArgs e)
		{
			PointF posF = new PointF(e.Position.X, e.Position.Y);
			foreach (GuiFrame frame in Children)
			{
				frame.OnMouseMove(e);
				if (frame.Rect.Contains(posF))
				{
					if (!frame.MouseOver)
					{
						frame.OnMouseEnter(e);
					}
					frame.MouseOver = true;
				}
				else if (frame.MouseOver)
				{
					frame.MouseOver = false;
					frame.OnMouseLeave(e);
				}
			}
		}
		public virtual void OnMouseDown(MouseButtonEventArgs e)
		{
			foreach (GuiFrame frame in Children)
			{
				if (frame.MouseOver)
				{
					frame.MouseDown = true;
				}
				frame.OnMouseDown(e);
			}
		}
		public virtual void OnMouseUp(MouseButtonEventArgs e)
		{
			foreach (GuiFrame frame in Children)
			{
				if (frame.MouseOver)
				{
					if (frame.MouseDown)
					{
						frame.OnMouseClick(e);
					}
				}
				frame.OnMouseUp(e);
				frame.MouseDown = false;
			}
		}
		public override void OnResize()
		{
			foreach (GuiFrame frame in Children)
			{
				frame.OnResize();
			}
			base.OnResize();
		}
		public virtual void OnUnload()
		{
			foreach (GuiFrame frame in Children)
			{
				frame.OnUnload();
			}
		}
	}
}