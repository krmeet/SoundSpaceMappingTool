package mapEditor.BaseUI;

import java.awt.*;
import java.util.ArrayList;
import javax.swing.*;
import mapEditor.*;

public class UIPanel extends JPanel {
	
	public String Name = "Untitled";
	public ArrayList<UIBase> Children = new ArrayList<UIBase>();
	
	public UIPanel() {
		super();
	}
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		this.Children.forEach((child)->{
			child.DrawToGraphics(this, g);
		});
		Main.EditorWindow.setTitle("Sound Space Mapping Tool - "+this.Name);
	}

}
