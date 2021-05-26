package mapEditor.BaseUI;

import java.awt.*;
import java.awt.geom.*;
import javax.swing.*;

public class UITextLabel extends UIBase {
	
	public String Text = "Label";
	public Color TextColor = Color.GRAY;
	public Font TextFont = Font.decode("Courier New");
	
	protected void Draw(Graphics2D g) {
		Rectangle2D bounds = TextFont.getStringBounds(Text, g.getFontRenderContext());
		g.setFont(TextFont);
		g.setColor(TextColor);
		g.drawString(Text,
				(float)(_position.X+(_size.X/2)-(bounds.getWidth()/2)),
				(float)(_position.Y+(_size.Y/2)+(bounds.getHeight()/2))
		);
	}
	
}
