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
				(float)(AbsolutePosition.X+(AbsoluteSize.X/2)-(bounds.getWidth()/2)),
				(float)(AbsolutePosition.Y+(AbsoluteSize.Y/2)+(bounds.getHeight()/2))
		);
	}
	
}
