package mapEditor;

import java.awt.*;
import java.awt.event.MouseEvent;

import javax.swing.*;
import mapEditor.BaseUI.*;

public class Window extends JFrame {
	
	private UIPanel currentPanel;

	public Window(int W, int H) {
		super();
		setTitle("Sound Space Mapping Tool");
		setSize(W, H);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	
	public void setPanel(UIPanel panel) {
		if (currentPanel != null) {
			remove(currentPanel);
		}
		currentPanel = panel;
		add(currentPanel);
		currentPanel.repaint();
		repaint();
		if (!isVisible()) {
			setVisible(true);
		}
	}
	
}
