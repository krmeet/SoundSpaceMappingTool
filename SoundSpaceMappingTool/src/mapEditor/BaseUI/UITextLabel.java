package mapEditor.BaseUI;

public class UITextLabel extends UIBase {
	
	public String Text;

	public UITextLabel() {
		this("Label",0,0,200,50);
	}
	public UITextLabel(String text,int x,int y,int w,int h) {
		super(x,y,w,h);
		this.Text = text;
	}
	
}
