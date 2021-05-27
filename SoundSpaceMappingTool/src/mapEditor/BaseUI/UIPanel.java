package mapEditor.BaseUI;

import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;
import javax.swing.*;
import mapEditor.*;

public class UIPanel extends JPanel {
	
	public String Name = "Untitled";
	public ArrayList<UIBase> Children = new ArrayList<UIBase>();
	
	public UIPanel() {
		super();
		enableEvents(AWTEvent.MOUSE_EVENT_MASK);
	}
	
	@Override
	public void paint(Graphics g) {
		super.paint(g);
		Children.forEach((child)->{
			child.DrawToGraphics(this, g);
		});
		Main.EditorWindow.setTitle("Sound Space Mapping Tool - "+this.Name);
	}
	
	@Override
	protected void processMouseEvent(MouseEvent e) {
		Children.forEach((child)->{
			boolean isTouching = (child.AbsolutePosition.X < e.getX()) &&
					(child.AbsolutePosition.Y < e.getY()) &&
					(child.AbsolutePosition.X+child.AbsoluteSize.X > e.getX()) &&
					(child.AbsolutePosition.Y+child.AbsoluteSize.Y > e.getY());
			System.out.println(isTouching);
			if (isTouching) {
				if (e.getID() == MouseEvent.MOUSE_CLICKED) {
					child.MouseClick(e);
				} else if (e.getID() == MouseEvent.MOUSE_PRESSED) {
					child.MouseDown(e);
				} else if (e.getID() == MouseEvent.MOUSE_RELEASED) {
					child.MouseUp(e);
				}
			} else {
				if (e.getID() == MouseEvent.MOUSE_RELEASED) {
					if (child.IsMouseDown()) {
						child.MouseUp(e);
					}
				}
			}
		});
		super.processMouseEvent(e);
	}
}
