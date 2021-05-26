package mapEditor.BaseUI;

public class UDim2 {

	public UDim X = new UDim();
	public UDim Y = new UDim();
	
	public UDim2() {
		this(0,0,0,0);
	}
	public UDim2(float xScale, int xOffset, float yScale, int yOffset) {
		X.Scale = xScale;
		Y.Scale = yScale;
		X.Offset = xOffset;
		Y.Offset = yOffset;
	}
	
}
