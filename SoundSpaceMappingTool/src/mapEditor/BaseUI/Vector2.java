package mapEditor.BaseUI;

public class Vector2 {
	
	public float X;
	public float Y;
	
	public Vector2() {
		this(0,0);
	}
	public Vector2(float x, float y) {
		X = x;
		Y = y;
	}
	
	public float Magnitude() {
		return (float)Math.hypot((double)X, (double)Y);
	}
	public float Dot(Vector2 b) {
		return (X * b.X) + (Y * b.Y); 
	}
	public Vector2 Normalise() {
		return Divide(Magnitude());
	}
	public Vector2 Add(Vector2 b) {
		return new Vector2(X+b.X,Y+b.Y);
	}
	public Vector2 Subtract(Vector2 b) {
		return new Vector2(X-b.X,Y-b.Y);
	}
	public Vector2 Divide(float b) {
		return new Vector2(X/b,Y/b);
	}
	public Vector2 Multiply(float b) {
		return new Vector2(X*b,Y*b);
	}

}
