package mapEditor.BaseUI;

import javax.swing.*;

public class UIBase extends JComponent {
	
	public Vector2 Position;
	public Vector2 Size;
	
	public UIBase() {
		this(0,0,200,100);
	}
	public UIBase(int x, int y, int w, int h) {
		this.Position = new Vector2(x,y);
		this.Size = new Vector2(w,h);
	}
	
}
