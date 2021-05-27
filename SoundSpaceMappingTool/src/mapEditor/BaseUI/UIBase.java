package mapEditor.BaseUI;

import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.util.function.*;
import javax.swing.*;

public class UIBase {
	
	public Color BackgroundColor = Color.WHITE;
	public UDim2 Position = new UDim2();
	public UDim2 Size = new UDim2(0,200,0,200);
	public Vector2 AbsolutePosition;
	public Vector2 AbsoluteSize;
	protected boolean _mouseDown = false;
	private Consumer<MouseEvent> _clickListener = new Consumer<MouseEvent>() {
		@Override
		public void accept(MouseEvent t) {}
	};
	private Consumer<MouseEvent> _downListener = new Consumer<MouseEvent>() {
		@Override
		public void accept(MouseEvent t) {}
	};
	private Consumer<MouseEvent> _upListener = new Consumer<MouseEvent>() {
		@Override
		public void accept(MouseEvent t) {}
	};
	
	public UIBase() {
		AbsolutePosition = new Vector2();
		AbsoluteSize = new Vector2();
	}
	
	public void OnMouseClick(Consumer<MouseEvent> e) {
		_clickListener = e;
	}
	public void OnMouseDown(Consumer<MouseEvent> e) {
		_downListener = e;
		_mouseDown = true;
	}
	public void OnMouseUp(Consumer<MouseEvent> e) {
		_upListener = e;
		_mouseDown = false;
	}
	public void MouseClick(MouseEvent e) {
		_clickListener.accept(e);
	}
	public void MouseDown(MouseEvent e) {
		_downListener.accept(e);
	}
	public void MouseUp(MouseEvent e) {
		_upListener.accept(e);
	}
	public boolean IsMouseDown() {
		return _mouseDown;
	}
	
	public void DrawToGraphics(UIPanel parent, Graphics g) {
		Rectangle bounds = parent.getBounds();
		int totalX = (int)(Position.X.Scale*(float)bounds.width)+Position.X.Offset;
		int totalY = (int)(Position.Y.Scale*(float)bounds.height)+Position.Y.Offset;
		int totalSX = (int)(Size.X.Scale*(float)bounds.width)+Size.X.Offset;
		int totalSY = (int)(Size.Y.Scale*(float)bounds.height)+Size.Y.Offset;
		AbsolutePosition.X = totalX;
		AbsolutePosition.Y = totalY;
		AbsoluteSize.X = totalSX;
		AbsoluteSize.Y = totalSY;
		Graphics2D g2d = (Graphics2D) g;
		g2d.setColor(BackgroundColor);
		g2d.fillRect((int)AbsolutePosition.X, (int)AbsolutePosition.Y, (int)AbsoluteSize.X, (int)AbsoluteSize.Y);
		Draw(g2d);
	}
	
	protected void Draw(Graphics2D g) {}
	
}
