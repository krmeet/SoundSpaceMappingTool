package mapEditor;

import mapEditor.BaseUI.*;
import mapEditor.UI.*;

public class Main {
	public static Window EditorWindow;

	public static void main(String[] args) {
		EditorWindow = new Window(800,600);
		EditorWindow.setPanel(new StartMenu());
		EditorWindow.repaint();
	}

}
