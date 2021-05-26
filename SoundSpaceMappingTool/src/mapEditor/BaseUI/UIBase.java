package mapEditor.BaseUI;

import java.awt.*;
import javax.swing.*;

public class UIBase {
	
	public Color BackgroundColor = Color.WHITE;
	public UDim2 Position = new UDim2();
	public UDim2 Size = new UDim2(0,200,0,200);
	protected Vector2 _position;
	protected Vector2 _size;
	
	public UIBase() {
		_position = new Vector2();
		_size = new Vector2();
	}
	
	public void DrawToGraphics(UIPanel parent, Graphics g) {
		Rectangle bounds = parent.getBounds();
		int totalX = (int)(Position.X.Scale*(float)bounds.width)+Position.X.Offset;
		int totalY = (int)(Position.Y.Scale*(float)bounds.height)+Position.Y.Offset;
		int totalSX = (int)(Size.X.Scale*(float)bounds.width)+Size.X.Offset;
		int totalSY = (int)(Size.Y.Scale*(float)bounds.height)+Size.Y.Offset;
		_position.X = totalX;
		_position.Y = totalY;
		_size.X = totalSX;
		_size.Y = totalSY;
		Graphics2D g2d = (Graphics2D) g;
		g2d.setColor(BackgroundColor);
		g2d.fillRect((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y);
		Draw(g2d);
	}
	
	protected void Draw(Graphics2D g) {}
	
}
