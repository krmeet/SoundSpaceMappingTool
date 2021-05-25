using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
namespace GUI
{
	public class GuiFrame : GuiScreen
	{
		public string Image;
		public bool OnScreen { get; protected set; }
		public bool Visible = true;
		public int ZIndex = 0;
		public Color4 Colour = new Color4(255, 255, 255, 255);
		public bool MouseOver;
		public bool MouseDown;
		public GuiFrame() : base()
		{
			Size = new Vector4(0, 200, 0, 200);
		}
		public GuiFrame(Vector4 p, Vector4 s) : base(p, s) { }
		public override void Render(FrameEventArgs e)
		{
			var clSize = Window.ClientSize;
			OnScreen = (
				Rect.X <= clSize.Width &&
				Rect.Y <= clSize.Height &&
				Rect.X + Rect.Width >= 0 &&
				Rect.Y + Rect.Height >= 0
			);
			if (Visible && OnScreen)
			{
				if (Parent != null && Parent.ClipDescendants)
				{
					GL.Enable(EnableCap.ScissorTest);
					GL.Scissor((int)(Parent.AbsPosition.X),
					(int)(clSize.Height - Parent.AbsPosition.Y - Parent.AbsSize.Y),
					(int)(Parent.AbsSize.X),
					(int)(Parent.AbsSize.Y));
				}
				GL.Color4(Colour);
				if (Image != null) GLR.RenderImageRect(Rect, ZIndex, TextureManager.Get(Image));
				else GLR.RenderRect(Rect, ZIndex);
				base.Render(e);
				if (Parent != null && Parent.ClipDescendants) GL.Disable(EnableCap.ScissorTest);
			}
		}
		public virtual void OnMouseEnter(MouseMoveEventArgs e)
		{ }
		public virtual void OnMouseLeave(MouseMoveEventArgs e)
		{ }
		public virtual void OnMouseClick(MouseButtonEventArgs e)
		{ }
	}
}