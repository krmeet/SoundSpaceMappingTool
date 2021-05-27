package mapEditor.UI;

import java.awt.*;
import java.awt.event.*;
import java.util.Random;

import mapEditor.BaseUI.*;

public class StartMenu extends UIPanel {

	public StartMenu() {
		super();
		this.Name = "Project Selection";
		this.setBackground(new Color(0f,0f,0f));
		UITextLabel uiTest = new UITextLabel();
		this.Children.add(uiTest);
		uiTest.Position.X.Scale = 0.5f;
		uiTest.Position.Y.Scale = 0.5f;
		uiTest.TextFont = Font.decode("Arial-BOLD-24");
		uiTest.OnMouseClick((MouseEvent e)->{
			uiTest.Position.X.Offset -= 1;
		});
	}
	
}
