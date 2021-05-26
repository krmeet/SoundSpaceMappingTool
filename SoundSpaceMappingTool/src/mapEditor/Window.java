package mapEditor;

import java.awt.*;
import javax.swing.*;
import mapEditor.BaseUI.*;

public class Window extends JFrame {
	
	private UIPanel currentPanel;

	public Window(int W, int H) {
		super();
		this.setTitle("Sound Space Mapping Tool");
		this.setSize(W, H);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setVisible(true);
	}
	
	public void setPanel(UIPanel panel) {
		if (currentPanel != null) {
			this.remove(currentPanel);
		}
		currentPanel = panel;
		this.add(currentPanel);
	}
	
}
