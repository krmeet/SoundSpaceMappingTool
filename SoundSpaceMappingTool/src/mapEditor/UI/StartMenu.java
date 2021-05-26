package mapEditor.UI;

import java.awt.*;
import mapEditor.BaseUI.*;

public class StartMenu extends UIPanel {

	public StartMenu() {
		super();
		this.Name = "Project Selection";
		this.setBackground(new Color(0f,0f,0f));
		UIBase uiTest = new UITextLabel();
		uiTest.Position.X.Scale = 0.5f;
		uiTest.Position.Y.Scale = 0.5f;
		this.Children.add(uiTest);
	}
	
}
