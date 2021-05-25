package mapEditor.BaseUI;

import java.awt.*;
import javax.swing.*;

import mapEditor.Main;

public class UIPanel extends JPanel {
	
	public String Name = "Untitled";
	
	public UIPanel() {
		super();
	}
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		Main.EditorWindow.setTitle("Sound Space Mapping Tool - "+this.Name);
	}
	
}
